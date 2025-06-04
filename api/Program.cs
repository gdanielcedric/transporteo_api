using Microsoft.EntityFrameworkCore;
using Transporteo.Data;
using Transporteo.Helpers;
using Transporteo.Services.Implementations;
using Transporteo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// connexion string
builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseNpgsql(builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection")));

// service registration
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IVoyageService, VoyageService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();
builder.Services.AddScoped<IBusService, BusService>();
builder.Services.AddScoped<IChauffeurService, ChauffeurService>();
builder.Services.AddScoped<ILigneService, LigneService>();

// mapping profile
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
