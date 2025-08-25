using AutoMapper;
using Bank.Application.DTO.Person;
using Bank.Application.Exceptions;
using Bank.Application.Repositories;
using Bank.Application.Resources;
using Bank.Application.Services;
using Bank.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bank.Infrastructure.Services
{
    public class PersonService(IMapper mapper, IPersonRepository personRepository, IValidator<AddPersonRequest> addPersonRequestValidator, IValidator<EditPersonRequest> editPersonRequestValidator) : IPersonService
    {
        public async Task<GetPersonModel> Get(int personId)
        {
            var personEntity = await personRepository.GetByIdAsync(personId);
            if (personEntity == null)
                throw new NotFoundException(PersonMessages.NoFound);

            var result = mapper.Map<GetPersonModel>(personEntity);

            return result;
        }

        public async Task<GetPersonModel> Add(AddPersonRequest person)
        {
            var validation = addPersonRequestValidator.Validate(person);
            if (!validation.IsValid)
                throw new ValidationModelException(validation.Errors);

            var personEntity = mapper.Map<Person>(person);
            await personRepository.AddAsync(personEntity);
            await personRepository.CommitAsync();
            return mapper.Map<GetPersonModel>(personEntity);
        }

        public async Task Update(int personId, EditPersonRequest person)
        {
            var validation = editPersonRequestValidator.Validate(person);
            if (!validation.IsValid)
                throw new ValidationModelException(validation.Errors);

            if (personId != person.PersonId)
                throw new BadRequestException(PersonMessages.InvalidId);

            var personEntity = await personRepository.GetByIdAsync(person.PersonId);
            if (personEntity == null)
                throw new NotFoundException(PersonMessages.NoFound);

            mapper.Map(person, personEntity);
            personRepository.Update(personEntity);
            await personRepository.CommitAsync();
        }

        public async Task Delete(int personId)
        {
            if (personId <= 0)
                throw new BadRequestException(PersonMessages.InvalidId);

            var personEntity = await personRepository.GetByIdAsync(personId);
            if (personEntity == null)
                throw new NotFoundException(PersonMessages.NoFound);

            personRepository.Delete(personEntity);
            await personRepository.CommitAsync();
        }

        public async Task<List<GetPersonModel>> GetAll()
        {
            var persons = personRepository.Fetch();

            var result = await mapper.ProjectTo<GetPersonModel>(persons).ToListAsync();

            return result;
        }
    }
}
