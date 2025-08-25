using AutoMapper;
using Bank.Application.Repositories;
using Bank.Application.Services;
using Bank.Application.Validators.Person;
using Bank.Infrastructure.Data;
using Bank.Infrastructure.Repositories;
using Bank.Infrastructure.Services;
using Bank.WebAPI.Filter;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(option =>
{
    option.Filters.Add<ExceptionFilter>();
}).AddNewtonsoftJson(); ;

builder.Services.AddValidatorsFromAssemblyContaining<AddPersonRequestValidator>();


builder.Services.AddDbContext<BankDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


#region Automapper
var mapperConfig = new MapperConfiguration(m =>
{
    m.AddProfile(new Bank.Application.Mappings.MappingProfile());
});

builder.Services.AddSingleton(mapperConfig.CreateMapper());
#endregion Automapper

#region Repositories
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
#endregion Repositories

#region Services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
#endregion Services

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
