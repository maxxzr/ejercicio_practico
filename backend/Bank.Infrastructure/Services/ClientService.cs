using AutoMapper;
using Bank.Application.DTO.Client;
using Bank.Application.DTO.Person;
using Bank.Application.Exceptions;
using Bank.Application.Models;
using Bank.Application.Repositories;
using Bank.Application.Resources;
using Bank.Application.Services;
using Bank.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bank.Infrastructure.Services
{
    public class ClientService(
        IMapper mapper,
        IClientRepository clientRepository, IPersonRepository personRepository, IAccountRepository accountRepository,
        IValidator<AddClientRequest> addClientRequestValidator, IValidator<EditClientRequest> editClientRequestValidator
    ) : IClientService
    {
        public async Task<GetClientModel> Get(int clientId)
        {
            var clientQuery = clientRepository.Fetch().Where(x => x.ClientId == clientId);
            if (!clientQuery.Any())
                throw new NotFoundException(ClientMessages.NoFound);

            var result = await mapper.ProjectTo<GetClientModel>(clientQuery).FirstOrDefaultAsync();

            return result;
        }

        public async Task<ResponseResult> Add(AddClientRequest client)
        {
            var result = new ResponseResult();
            var existPerson = false;

            var validation = addClientRequestValidator.Validate(client);
            if (!validation.IsValid)
                throw new ValidationModelException(validation.Errors);

            var person = await personRepository.Fetch().FirstOrDefaultAsync(x => x.DocumentNumber == client.DocumentNumber);

            if (person != null)
            {
                var clientExist = await clientRepository.Fetch().AnyAsync(x => x.PersonId == person.PersonId);
                if (clientExist)
                    throw new BadRequestException(ClientMessages.AlreadyExists);

                mapper.Map(client, person);
                personRepository.Update(person);
                await personRepository.CommitAsync();
                existPerson = true;
            }
            else
            {
                person = mapper.Map<Person>(client);
                await personRepository.AddAsync(person);
                await personRepository.CommitAsync();
            }

            var clientEntity = mapper.Map<Client>(client);
            clientEntity.Person = person;

            await clientRepository.AddAsync(clientEntity);
            await clientRepository.CommitAsync();

            result.DataId = clientEntity.ClientId;
            result.Message = existPerson ? ClientMessages.SuccessfulRegistrationExistPerson : ClientMessages.SuccessfulRegistration;

            return result;
        }

        public async Task<ResponseResult> Update(int clientId, EditClientRequest client)
        {
            var result = new ResponseResult();

            var validation = editClientRequestValidator.Validate(client);
            if (!validation.IsValid)
                throw new ValidationModelException(validation.Errors);

            if (clientId != client.ClientId)
                throw new BadRequestException(ClientMessages.InvalidId);

            var clientEntity = await clientRepository.Fetch().FirstOrDefaultAsync(x => x.ClientId == client.ClientId);
            if (clientEntity == null)
                throw new NotFoundException(ClientMessages.NoFound);

            if (clientEntity.PersonId != client.PersonId)
                throw new BadRequestException(ClientMessages.ErrorNoUpdatePersonId);

            var personEntity = await personRepository.Fetch().FirstOrDefaultAsync(x => x.PersonId == client.PersonId);
            if (personEntity == null)
                throw new NotFoundException(PersonMessages.NoFound);

            mapper.Map(client, personEntity);
            mapper.Map(client, clientEntity);
            personRepository.Update(personEntity);
            clientRepository.Update(clientEntity);
            await clientRepository.CommitAsync();

            result.DataId = clientEntity.ClientId;
            result.Message = ClientMessages.SuccessfullyUpdated;

            return result;
        }

        public async Task<ResponseResult> Delete(int clientId)
        {
            var result = new ResponseResult();
            if (clientId <= 0)
                throw new BadRequestException(ClientMessages.InvalidId);

            var clientEntity = await clientRepository.Fetch().FirstOrDefaultAsync(x => x.ClientId == clientId);
            if (clientEntity == null)
                throw new NotFoundException(ClientMessages.NoFound);

            clientRepository.Delete(clientEntity);
            await clientRepository.CommitAsync();

            result.Message = ClientMessages.SuccessfullyDeleted;

            return result;
        }

        public async Task<List<GetClientModel>> GetAll(string name)
        {
            var clients = clientRepository.Fetch().Where(x => x.Person.Name.Contains(name));

            var result = await mapper.ProjectTo<GetClientModel>(clients).ToListAsync();

            return result;
        }

        public async Task<List<GetAccountClientModel>> GetAccounts(int clientId)
        {
            var accountsQuery = accountRepository.Fetch().Where(x => x.ClientId == clientId);

            var accounts = await mapper.ProjectTo<GetAccountClientModel>(accountsQuery).ToListAsync();

            return accounts;
        }
    }
}
