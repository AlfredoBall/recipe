using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// TODO 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conStrBuilder = new SqlConnectionStringBuilder();

conStrBuilder.InitialCatalog = builder.Configuration["Database"];
conStrBuilder.DataSource = builder.Configuration["DataSource"];
conStrBuilder.UserID = builder.Configuration["UserID"];
conStrBuilder.Password = builder.Configuration["Password"];

Console.WriteLine("RECIPE CONNECTION STRING: " + conStrBuilder.ConnectionString);

builder.Services.AddDbContext<Recipe.Data.Context>(options =>
                options.UseSqlServer(conStrBuilder.ConnectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Most likely won't even use this for local development - instead a bundle will be created
// Maybe for custom local seeding
// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     try
//     {   
        
//         // TODO pass in the PlanningContext
//         var recipeContext = services.GetRequiredService<Recipe.Data.Context>();
           // A DbInitializer would need to be created for local seeding
//         Recipe.API.Data.DbInitializer.Initialize(recipeContext);
//     }
//     catch (Exception ex)
//     {
//         var logger = services.GetRequiredService<ILogger<Program>>();
//         logger.LogError(ex, "An error occurred creating the DB.");
//     }
// }   

app.UseCors(options => {
    options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
