using CP2.Application.Services;
using CP2.Data.Repositories;
using CP2.Domain.Interfaces;
using CP2.IoC;

var builder = WebApplication.CreateBuilder(args);

// Adicionando inje��o de depend�ncia para os servi�os e reposit�rios
builder.Services.AddScoped<IVendedorRepository, VendedorRepository>();
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddScoped<IVendedorApplicationService, VendedorApplicationService>();
builder.Services.AddScoped<IFornecedorApplicationService, FornecedorApplicationService>();

// Add services to the container.
builder.Services.AddControllers();

// Configurar Swagger para documenta��o da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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
