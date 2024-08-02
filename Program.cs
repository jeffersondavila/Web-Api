using webapi;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("connection"));
builder.Services.AddSqlServer<TareasContext>("Data Source=LAPTOP-07NSNMOC;Initial Catalog=TareasDb;user id=sa;password=loc@del@rea;TrustServerCertificate=True");
builder.Services.AddScoped<ITareaService, TareaService>();
builder.Services.AddScoped<IHelloWordService, HelloWordService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// app.UseWelcomePage();

// app.UseTimeMiddleware();

app.MapControllers();

app.Run();
