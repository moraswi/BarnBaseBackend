using BarnBase.Data;
using BarnBase.Interfaces.Repository;
using BarnBase.Interfaces.Services;
using BarnBase.Repository;
using BarnBase.Services;
using BarnBase.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Runtime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// DataContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);


//Repository
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IFarmRepository, FarmRepository>();
builder.Services.AddScoped<IFixedPriceSaleRepository, FixedPriceSaleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBreedingRepository, BreedingRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

//services
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IFarmService, FarmService>();
builder.Services.AddScoped<IFixedPriceSaleService, FixedPriceSaleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBreedingService, BreedingService>();
builder.Services.AddScoped<ITaskService, TaskService>();
//builder.Services.AddScoped<IEmailService, EmailService>();

//AddAutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbSettings
builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Farmer App Api Gateway"));


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
