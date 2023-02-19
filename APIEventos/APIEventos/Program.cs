using APIEventos.Filter;
using APIEventos.Infra.Data.Repository;
using APIEventos.Service;
using APIEventos.Service.Interface;
using APIEventos.Service.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(ExcecaoGeralFilter));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var chaveCripto = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("SECRET_KEY"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(chaveCripto),
                    ValidateIssuer = true,
                    ValidIssuer = "APIPessoa.com",
                    ValidateAudience = true,
                    ValidAudience = "SuaSaude.com"
                };
            });

builder.Services.AddScoped<ICityEventServiceRepository, CityEventRepository>();
builder.Services.AddScoped<ICityEventService, CityEventService>();

builder.Services.AddScoped<IEventReservationRepository, EventReservationRepository>();
builder.Services.AddScoped<IEventReservationService, EventReservationService>();
//builder.Services.AddScoped<IGerarTokenService, GerarTokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
