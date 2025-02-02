using DSV.Core.Services;
using DSV.Persistence.Sql;
using DSV.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddCoreServices();
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers()
    .WithOpenApi();

// using var scope = app.Services.CreateScope(); // TODO: ...
// var context = scope.ServiceProvider.GetRequiredService<DsvDbContext>();
// await context.Database.MigrateAsync();

app.Run();