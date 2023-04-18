using Api.Businness.Manager;
using Api.Logger;
using Api.Security;
using Api.Transaccion.Security;
using Api.Transaccion.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Transaccion",
        Version = "v1",
        Description = "Api Transaccion descripción",
        Contact = new OpenApiContact
        {
            Name = "leacim",
            Email = "@gmail.com"
        }
    });
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "basic"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddTransient<IManagerCuentas, ManagerCuentas>();
builder.Services.AddTransient<IServiceCuentas, ServiceCuentas>();

builder.Services.AddTransient<IManagerMovimientos, ManagerMovimientos>();
builder.Services.AddTransient<IServiceMovimientos, ServiceMovimientos>();

builder.Services.AddTransient<IManagerReporte, ManagerReporte>();
builder.Services.AddTransient<IServiceReporte, ServiceReporte>();

builder.Services.AddTransient<IManagerSecurity, ManagerSecurity>();

builder.Services.AddLogger();


//auntenticacion basica
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthHandler>("BasicAuthentication", null);

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