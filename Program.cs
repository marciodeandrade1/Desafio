using Desafio.Data;
using Desafio.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ILogradouroService, LogradouroService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddDbContext<DbContextClass>();

//Api aberta para o mundo conforme solicitado 
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        //M�todo AllowAnyOrigin permite qualquer requisi��o
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});


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
