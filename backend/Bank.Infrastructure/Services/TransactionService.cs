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
    public class TransactionService(
            IMapper mapper,
            ITransactionRepository transactionRepository
        ) : ITransactionService
    {
        public async Task<List<GetTransactionResponse>> GetAll()
        {
            var accounts = transactionRepository.Fetch();

            var result = await mapper.ProjectTo<GetTransactionResponse>(accounts).ToListAsync();

            return result;
        }
    }
}
