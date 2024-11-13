using breaking_bad.api.ConfigDependency;
using breaking_bad.infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register Depndencies
builder.Services.ResolveDependency();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// configure Dbcontext class
builder.Services.AddDbContextPool<BreakingBadContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("BreakingbadConnectionStringMySQL");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), options =>
    options.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null));
});


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
