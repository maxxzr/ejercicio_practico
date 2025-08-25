using AutoMapper;
using Bank.Application.DTO.Client;
using Bank.Application.Exceptions;
using Bank.Application.Mappings;
using Bank.Application.Models;
using Bank.Application.Repositories;
using Bank.Application.Resources;
using Bank.Application.Validators.Client;
using Bank.Domain.Entities;
using Bank.Infrastructure.Repositories;
using Bank.Infrastructure.Services;
using FluentValidation;
using MockQueryable;
using Moq;
using System;

namespace Bank.Infrastructure.Test
{
    [TestClass]
    public sealed class ClientServiceTest
    {
        private ClientService clientService;
        private IMapper mapper;
        private Mock<IClientRepository> clientRepository = new();
        private Mock<IPersonRepository> personRepository = new();
        private Mock<IAccountRepository> accountRepository = new();

        private AddClientRequestValidator addClientRequestValidator = new();
        private EditClientRequestValidator editClientRequestValidator = new();

        [TestInitialize]
        public void Initialize()
        {
            var mapperConfiguracion = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            mapper = mapperConfiguracion.CreateMapper();

            clientService = new ClientService(mapper, clientRepository.Object, personRepository.Object, accountRepository.Object, addClientRequestValidator, editClientRequestValidator);
        }

        #region Get
        [TestMethod]
        public async Task Get_Ok()
        {
            CreateDataBase();
            var result = await clientService.Get(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ClientId);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public async Task Get_Error_NotFoundException()
        {
            CreateDataBase();
            var result = await clientService.Get(3);
        }
        #endregion Get

        #region Add
        [TestMethod]
        public async Task Add_Ok_NoExistPerson()
        {
            var addClientRequest = new AddClientRequest
            {
                DocumentNumber = "987654321",
                Name = "John",
                Address = "Calle falsa 123",
                GenderId = Domain.Enums.GenderId.Male,
                Password = "Clave#123",
                RepeatPassword = "Clave#123",
                Phone = "996655777",
                BirthDate = DateTime.Now.AddYears(-30)
            };

            CreateDataBase();

            Client client = new();
            clientRepository.Setup(x => x.AddAsync(It.IsAny<Client>())).Callback<Client>(p =>
            {
                client = p;
                client.ClientId = 2;
            });

            var result = await clientService.Add(addClientRequest);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ResponseResult));
            Assert.AreEqual(client.ClientId, result.DataId);
        }

        [TestMethod]
        public async Task Add_Ok_ExistPerson()
        {
            var addClientRequest = new AddClientRequest
            {
                DocumentNumber = "147852369",
                Name = "Max",
                Address = "Calle falsa 123",
                GenderId = Domain.Enums.GenderId.Male,
                Password = "Clave#123",
                RepeatPassword = "Clave#123",
                Phone = "996655777",
                BirthDate = DateTime.Now.AddYears(-30)
            };

            CreateDataBase();

            Client client = new();
            clientRepository.Setup(x => x.AddAsync(It.IsAny<Client>())).Callback<Client>(p =>
            {
                client = p;
                client.ClientId = 3;
            });

            var result = await clientService.Add(addClientRequest);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ResponseResult));
            Assert.AreEqual(client.ClientId, result.DataId);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationModelException))]
        public async Task Add_Error_ValidationModelException()
        {
            var addClientRequest = new AddClientRequest
            {
                DocumentNumber = "999",
                Name = "Max",
                Address = "Calle falsa 123",
                Password = "Clave#123",
                Phone = "996655777",
                BirthDate = DateTime.Now.AddYears(-30)
            };
            var result = await clientService.Add(addClientRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public async Task Add_Error_BadRequestException()
        {
            var addClientRequest = new AddClientRequest
            {
                DocumentNumber = "1234567890",
                Name = "Max",
                Address = "Calle falsa 123",
                GenderId = Domain.Enums.GenderId.Male,
                Password = "Clave#123",
                RepeatPassword = "Clave#123",
                Phone = "996655777",
                BirthDate = DateTime.Now.AddYears(-30)
            };

            CreateDataBase();
            var result = await clientService.Add(addClientRequest);
        }
        #endregion Add

        #region Update
        [TestMethod]
        public async Task Update_Ok()
        {
            var editClientRequest = new EditClientRequest
            {
                ClientId = 1,
                PersonId = 1,
                BirthDate = DateTime.Now.AddYears(-30),
                GenderId = Domain.Enums.GenderId.Male,
                Password = "Clave#1234",
                RepeatPassword = "Clave#1234",
                Phone = "987987987",
                StatusClientId = Domain.Enums.StatusClientId.Active,
                DocumentNumber = "1234567890",
                Name = "Nuevo Nombre",
                Address = "Calle falsa 123",
            };

            CreateDataBase();

            Person person = new();
            personRepository.Setup(x => x.Update(It.IsAny<Person>())).Callback<Person>(p =>
            {
                person = p;
            });

            Client client = new();
            clientRepository.Setup(x => x.Update(It.IsAny<Client>())).Callback<Client>(p =>
            {
                client = p;
            });

            var result = await clientService.Update(editClientRequest.ClientId, editClientRequest);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ResponseResult));
            Assert.AreEqual(person.Name, editClientRequest.Name);
            Assert.AreEqual(client.Password, editClientRequest.Password);
            Assert.AreEqual(client.ClientId, result.DataId);

        }

        [TestMethod]
        [ExpectedException(typeof(ValidationModelException))]
        public async Task Update_Error_ValidationModelException()
        {
            var editClientRequest = new EditClientRequest
            {
                ClientId = 1,
                PersonId = 1,
                BirthDate = DateTime.Now.AddYears(-10),
                Password = "clave#1234",
                RepeatPassword = "Clave#1234",
                Phone = "987987987",
                StatusClientId = Domain.Enums.StatusClientId.Active,
                DocumentNumber = "1234567890",
                Name = "Nuevo Nombre",
                Address = "Calle falsa 123",
            };
            var result = await clientService.Update(editClientRequest.ClientId, editClientRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public async Task Update_Error_BadRequestException()
        {
            var editClientRequest = new EditClientRequest
            {
                ClientId = 1,
                PersonId = 1,
                BirthDate = DateTime.Now.AddYears(-30),
                GenderId = Domain.Enums.GenderId.Male,
                Password = "Clave#1234",
                RepeatPassword = "Clave#1234",
                Phone = "987987987",
                StatusClientId = Domain.Enums.StatusClientId.Active,
                DocumentNumber = "1234567890",
                Name = "Nuevo Nombre",
                Address = "Calle falsa 123",
            };

            CreateDataBase();
            var result = await clientService.Update(3, editClientRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public async Task Update_Error_NotFoundException_Client()
        {
            var editClientRequest = new EditClientRequest
            {
                ClientId = 3,
                PersonId = 1,
                BirthDate = DateTime.Now.AddYears(-30),
                GenderId = Domain.Enums.GenderId.Male,
                Password = "Clave#1234",
                RepeatPassword = "Clave#1234",
                Phone = "987987987",
                StatusClientId = Domain.Enums.StatusClientId.Active,
                DocumentNumber = "1234567890",
                Name = "Nuevo Nombre",
                Address = "Calle falsa 123",
            };

            CreateDataBase();
            var result = await clientService.Update(editClientRequest.ClientId, editClientRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public async Task Update_Error_BadRequestException_Update_PersonId()
        {
            var editClientRequest = new EditClientRequest
            {
                ClientId = 1,
                PersonId = 9,
                BirthDate = DateTime.Now.AddYears(-30),
                GenderId = Domain.Enums.GenderId.Male,
                Password = "Clave#1234",
                RepeatPassword = "Clave#1234",
                Phone = "987987987",
                StatusClientId = Domain.Enums.StatusClientId.Active,
                DocumentNumber = "1234567890",
                Name = "Nuevo Nombre",
                Address = "Calle falsa 123",
            };

            CreateDataBase();
            var result = await clientService.Update(editClientRequest.ClientId, editClientRequest);
        }
        #endregion Update

        #region Delete
        [TestMethod]
        public async Task Delete_Ok()
        {
            CreateDataBase();
            var result = await clientService.Delete(1);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ResponseResult));
            Assert.AreEqual(ClientMessages.SuccessfullyDeleted, result.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public async Task Delete_Error_BadRequestException()
        {
            CreateDataBase();
            var result = await clientService.Delete(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public async Task Delete_Error_NotFoundException()
        {
            CreateDataBase();
            var result = await clientService.Delete(99);
        }
        #endregion Delete


        public void CreateDataBase()
        {
            var persons = new List<Person>{
                new Person
                {
                    PersonId = 1,
                    DocumentNumber = "1234567890",
                    Name = "John",
                    BirthDate = DateTime.Now.AddYears(-30)
                },
                new Person
                {
                    PersonId = 2,
                    DocumentNumber = "147852369",
                    Name = "Max",
                    BirthDate = DateTime.Now.AddYears(-30)
                }
            };
            clientRepository.Setup(x => x.Fetch()).Returns(new List<Client>
            {
                new Client
                {
                    ClientId = 1,
                    PersonId = 1,
                    Person = persons.First(x => x.PersonId == 1)
                }
            }.BuildMock());

            personRepository.Setup(x => x.Fetch()).Returns(persons.BuildMock());
        }
    }
}
