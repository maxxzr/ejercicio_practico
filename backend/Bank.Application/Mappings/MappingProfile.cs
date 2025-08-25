using AutoMapper;
using Bank.Application.DTO.Account;
using Bank.Application.DTO.Client;
using Bank.Application.DTO.Person;
using Bank.Application.DTO.Report;
using Bank.Application.DTO.Transaction;
using Bank.Domain.Entities;

namespace Bank.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Account
            CreateMap<Account, GetAccountModel>()
                .ForMember(d => d.ClientName, act => act.MapFrom(o => o.Client.Person.Name))
                .ForMember(d => d.AccountTypeDescription, act => act.MapFrom(o => o.AccountType.Description));

            CreateMap<AddAccountRequest, Account>()
                .ForMember(d => d.CurrentBalance, act => act.MapFrom(o => o.InitialBalance));

            CreateMap<EditAccountRequest, Account>()
                .ForMember(d => d.CurrentBalance, act => act.MapFrom(o => o.InitialBalance))
                .ForMember(d => d.ClientId, act => act.Ignore());
            #endregion Account

            #region Client
            CreateMap<Client, GetClientModel>()
                .ForMember(d => d.Name, act => act.MapFrom(o => o.Person.Name))
                .ForMember(d => d.DocumentNumber, act => act.MapFrom(o => o.Person.DocumentNumber))
                .ForMember(d => d.GenderId, act => act.MapFrom(o => o.Person.GenderId))
                .ForMember(d => d.Address, act => act.MapFrom(o => o.Person.Address))
                .ForMember(d => d.Phone, act => act.MapFrom(o => o.Person.Phone))
                .ForMember(d => d.BirthDate, act => act.MapFrom(o => o.Person.BirthDate));

            CreateMap<AddClientRequest, Client>();

            CreateMap<EditClientRequest, Client>();

            CreateMap<Account, GetAccountClientModel>();
            #endregion Client

            #region Person
            CreateMap<Person, GetPersonModel>();
            CreateMap<AddClientRequest, Person>();
            CreateMap<EditClientRequest, Person>();
            CreateMap<AddPersonRequest, Person>();
            CreateMap<EditPersonRequest, Person>();
            #endregion Person

            #region Transaction
            CreateMap<Transaction, GetAccountTransactionResponse>();
            CreateMap<Transaction, GetTransactionResponse>()
                .ForMember(d => d.AccountNumber, act => act.MapFrom(o => o.Account.Number))
                .ForMember(d => d.ClientName, act => act.MapFrom(o => o.Account.Client.Person.Name))
                .ForMember(d => d.AccountTypeDescription, act => act.MapFrom(o => o.Account.AccountType.Description))
                .ForMember(d => d.StatusAccountDescription, act => act.MapFrom(o => o.Account.StatusAccount.Description));

            #endregion Transaction

            #region reports
            CreateMap<Transaction, ReportTransactionResponse>()
                .ForMember(d => d.AccountNumber, act => act.MapFrom(o => o.Account.Number))
                .ForMember(d => d.ClientName, act => act.MapFrom(o => o.Account.Client.Person.Name));
            #endregion
        }
    }
}
