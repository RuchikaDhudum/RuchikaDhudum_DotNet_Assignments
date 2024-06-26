using EmployeeManagementSystemAssignment_Ruchika.Common;
using EmployeeManagementSystemAssignment_Ruchika.CosmosDB;
using EmployeeManagementSystemAssignment_Ruchika.Interface;
using EmployeeManagementSystemAssignment_Ruchika.ServiceFilters;
using EmployeeManagementSystemAssignment_Ruchika.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICosmosDBService, CosmosDBService>();
builder.Services.AddAutoMapper(typeof(AutomapperProfile));
builder.Services.AddScoped<BuildEmployeeBasicDetailFilter>();
builder.Services.AddScoped<BuildEmployeeAdditionalaDetailFilter>();
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
