using ApiIp.Interfaces;
using ApiIp.Rest;
using ApiIp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Registra as interfaces com suas implementações
IServiceCollection serviceCollection = builder.Services.AddSingleton<IpInterfaceRest, ApiRest>();
builder.Services.AddSingleton<IpInterfaceService, IpService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Ativa a interface gráfica
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();