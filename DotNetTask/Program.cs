using Core.Services.Abstraction;
using Core.Services.Implementation;
using Domain.Models;
using Domain.Repositories.Abstraction;
using Domain.Repositories.Implementation;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();



string endpointUri = configuration.GetSection("CosmosDbSettings:EndpointUri").Value;
string primaryKey = configuration.GetSection("CosmosDbSettings:PrimaryKey").Value;
string databaseName = configuration.GetSection("CosmosDbSettings:DatabaseName").Value;
string containerName = configuration.GetSection("CosmosDbSettings:ContainerName").Value;

var cosmosClient = new CosmosClient(endpointUri, primaryKey);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped((Func<IServiceProvider, IRepository<ProgramDetails>>)(provider =>
{

    return new Repository<ProgramDetails>(cosmosClient, databaseName, containerName);
}));
builder.Services.AddScoped<IRepository<ApplicationForm>>(provider =>
{
    return new Repository<ApplicationForm>(cosmosClient, databaseName, containerName);
});

builder.Services.AddScoped<IRepository<WorkFlow>>(provider =>
{
    return new Repository<WorkFlow>(cosmosClient, databaseName, containerName);
});

builder.Services.AddScoped<IRepository<Preview>>(provider =>
{
    return new Repository<Preview>(cosmosClient, databaseName, containerName);
});

builder.Services.AddScoped<IProgramDetailsService, ProgramDetailsService>();
builder.Services.AddScoped<IApplicationFormService, ApplicationFormService>();
builder.Services.AddScoped<IWorkFlowService, WorkFlowService>();
builder.Services.AddScoped<IPreviewService, PreviewService>();




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