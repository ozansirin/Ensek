using Ensek.API.Service;
using Ensek.Business.Abstract;
using Ensek.Business.Concrete;
using Ensek.Core;
using Ensek.Data.Abstract;
using Ensek.Data.Concrete;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DbContext, EnsekDbContext>();
builder.Services.AddTransient<IMeterReadingRepository, MeterReadingRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IMeterReadingService, MeterReadingService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddScoped<IContactAppService, ContactAppService>();
var conStr = builder.Configuration.GetConnectionString("EnsekDB");
builder.Services.AddDbContext<EnsekDbContext>(options => options.UseSqlServer(conStr));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
