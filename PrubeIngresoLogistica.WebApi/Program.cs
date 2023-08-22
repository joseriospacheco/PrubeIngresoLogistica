using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PrubeIngresoLogistica.Core.Interfaces.Repositories;
using PrubeIngresoLogistica.Core.Interfaces.Services;
using PrubeIngresoLogistica.Core.Services;
using PrubeIngresoLogistica.Infrastructure.Data;
using PrubeIngresoLogistica.Infrastructure.Mapping;
using PrubeIngresoLogistica.Infrastructure.Repositories;
using PrubeIngresoLogistica.WebApi.Controllers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();  

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<PersistenceContext>(opc => opc.UseSqlServer("name=DefaultConnection"));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new AutomapperProfile()));
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IClienteRepository,ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();


builder.Services.AddScoped<ILugarDestinoRepository, LugarDestinoRepository>();

builder.Services.AddScoped<IMedioTransporteRepository, MedioTransporteRepository>();
builder.Services.AddScoped<IMedioTranspoteService, MedioTransporteService>();


builder.Services.AddScoped<IEntregaRepository, EntregaRepository>();
builder.Services.AddScoped<IEntregaService, EntregaService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
