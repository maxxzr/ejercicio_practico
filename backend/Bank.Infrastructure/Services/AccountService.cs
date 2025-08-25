using AutoMapper;
using Bank.Application.DTO.Account;
using Bank.Application.DTO.Transaction;
using Bank.Application.Exceptions;
using Bank.Application.Models;
using Bank.Application.Repositories;
using Bank.Application.Resources;
using Bank.Application.Services;
using Bank.Domain.Entities;
using Bank.Domain.Enums;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bank.Infrastructure.Services
{
    public class AccountService(
            IMapper mapper,
            IAccountRepository accountRepository, IAccountTypeRepository accountTypeRepository, IClientRepository clientRepository, ITransactionRepository transactionRepository,
            IValidator<AddAccountRequest> addAccountRequestValidator, IValidator<EditAccountRequest> editAccountRequestValidator, IValidator<AddTransactionRequest> addTransactionRequest
        ) : IAccountService
    {
        public async Task<GetAccountModel> Get(int accountId)
        {
            var accountQuery = accountRepository.Fetch().Where(x => x.AccountId == accountId);
            if (!accountQuery.Any())
                throw new NotFoundException(AccountMessages.NoFound);

            var result = await mapper.ProjectTo<GetAccountModel>(accountQuery).FirstOrDefaultAsync();

            return result;
        }

        public async Task<ResponseResult> Add(AddAccountRequest account)
        {
            var result = new ResponseResult();

            var validation = addAccountRequestValidator.Validate(account);
            if (!validation.IsValid)
                throw new ValidationModelException(validation.Errors);

            var existClient = await clientRepository.Fetch().AnyAsync(x => x.ClientId == account.ClientId);
            if (!existClient)
                throw new NotFoundException(ClientMessages.NoFound);

            var existAccountType = await accountTypeRepository.Fetch().AnyAsync(x => x.AccountTypeId == account.AccountTypeId);
            if (!existAccountType)
                throw new NotFoundException(AccountMessages.NotFoundAccountType);

            var existAccountNumber = await accountRepository.Fetch().AnyAsync(x => x.Number == account.Number);
            if (existAccountNumber)
                throw new BadRequestException(AccountMessages.ExistAccountNumber);

            var accountEntity = mapper.Map<Account>(account);

            await accountRepository.AddAsync(accountEntity);
            await accountRepository.CommitAsync();

            result.DataId = accountEntity.AccountId;
            result.Message = AccountMessages.SuccessfulRegistration;

            return result;
        }

        public async Task<ResponseResult> Update(int accountId, EditAccountRequest account)
        {
            var result = new ResponseResult();

            var validation = editAccountRequestValidator.Validate(account);
            if (!validation.IsValid)
                throw new ValidationModelException(validation.Errors);

            var accountEntity = await accountRepository.GetByIdAsync(account.AccountId);

            if (accountEntity == null)
                throw new NotFoundException(AccountMessages.NoFound);

            var existAccountType = await accountTypeRepository.Fetch().AnyAsync(x => x.AccountTypeId == account.AccountTypeId);
            if (!existAccountType)
                throw new NotFoundException(AccountMessages.NotFoundAccountType);

            var existAccountNumber = await accountRepository.Fetch().AnyAsync(x => x.Number == account.Number && x.AccountId != account.AccountId);
            if (existAccountNumber)
                throw new BadRequestException(AccountMessages.ExistAccountNumber);

            mapper.Map(account, accountEntity);
            accountRepository.Update(accountEntity);
            await accountRepository.CommitAsync();

            result.DataId = accountEntity.AccountId;
            result.Message = AccountMessages.SuccessfullyUpdated;

            return result;
        }

        public async Task<ResponseResult> Delete(int accountId)
        {
            var result = new ResponseResult();
            if (accountId <= 0)
                throw new BadRequestException(AccountMessages.InvalidId);

            var accountEntity = await accountRepository.GetByIdAsync(accountId);
            if (accountEntity == null)
                throw new NotFoundException(AccountMessages.NoFound);

            accountRepository.Delete(accountEntity);
            await accountRepository.CommitAsync();

            result.Message = AccountMessages.SuccessfullyDeleted;

            return result;
        }

        public async Task<List<GetAccountModel>> GetAll()
        {
            var accounts = accountRepository.Fetch();

            var result = await mapper.ProjectTo<GetAccountModel>(accounts).ToListAsync();

            return result;
        }

        public async Task<ResponseResult> AddTransaction(int accountId, AddTransactionRequest transaction)
        {
            var result = new ResponseResult();

            var accountEntity = await accountRepository.GetByIdAsync(accountId);

            if (accountEntity == null)
                throw new NotFoundException(AccountMessages.NoFound);

            var amount = transaction.TransactionTypeId == TransactionTypeId.Credit ? transaction.Amount : -transaction.Amount;

            if (accountEntity.CurrentBalance + amount < 0)
                throw new BadRequestException(AccountMessages.InsufficientFunds);


            var transactionEntity = new Transaction
            {
                AccountId = accountId,
                InitialBalance = accountEntity.CurrentBalance,
                Amount = amount,
                TransactionTypeId = transaction.TransactionTypeId,
                DateTransaction = DateTime.UtcNow,
                Balance = accountEntity.CurrentBalance + amount
            };

            accountEntity.CurrentBalance += amount;

            await transactionRepository.AddAsync(transactionEntity);
            accountRepository.Update(accountEntity);
            await transactionRepository.CommitAsync();
            return result;

        }

        public async Task<List<GetAccountTransactionResponse>> GetTransactions(int accountId)
        {
            var transactionsQuery = transactionRepository.Fetch().Where(x => x.AccountId == accountId);

            var transactions = await mapper.ProjectTo<GetAccountTransactionResponse>(transactionsQuery).ToListAsync();

            return transactions;

        }
    }
}
