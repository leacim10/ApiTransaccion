using Api.Businness.Manager;
using Api.Logger;
using Api.Transaccion.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IManagerCuentas, ManagerCuentas>();
builder.Services.AddTransient<IServiceCuentas, ServiceCuentas>();

builder.Services.AddTransient<IManagerMovimientos, ManagerMovimientos>();
builder.Services.AddTransient<IServiceMovimientos, ServiceMovimientos>();

builder.Services.AddLogger();
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