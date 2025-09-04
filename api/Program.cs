using api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
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
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IPaiementService, PaiementService>();

// Configuration de l'authentification avec Keycloak
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(auth =>
{
    auth.Authority = builder.Configuration["Keycloack:Authority"] ?? "";
    auth.Audience = builder.Configuration["Keycloack:Audience"];

    auth.RequireHttpsMetadata = false; // désactive SSL pour développement local
    auth.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        RoleClaimType = ClaimTypes.Role,
        NameClaimType = "preferred_username"
    };

    // Extraction manuelle des rôles depuis realm_access.roles
    auth.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            var identity = context.Principal?.Identity as ClaimsIdentity;
            var realmAccess = context.Principal?.FindFirst("realm_access")?.Value;

            if (realmAccess != null)
            {
                var parsed = System.Text.Json.JsonDocument.Parse(realmAccess);
                if (parsed.RootElement.TryGetProperty("roles", out var roles))
                {
                    foreach (var role in roles.EnumerateArray())
                    {
                        var roleName = role.GetString();
                        if (!string.IsNullOrWhiteSpace(roleName))
                        {
                            identity?.AddClaim(new Claim(ClaimTypes.Role, roleName));
                        }
                    }
                }
            }

            return Task.CompletedTask;
        }
    };
});

//save Http client factory
builder.Services.AddHttpClient();

builder.Services.AddAuthorization();

// mapping profile
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
