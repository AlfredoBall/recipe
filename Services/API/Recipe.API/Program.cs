using Finbuckle.MultiTenant;
using GraphQL.Server.Ui.Voyager;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// TODO 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conStrBuilder = new SqlConnectionStringBuilder();

builder.Configuration.AddEnvironmentVariables().AddUserSecrets<Program>();

conStrBuilder.InitialCatalog = builder.Configuration["Database"];
conStrBuilder.DataSource = builder.Configuration["DataSource"];
conStrBuilder.UserID = builder.Configuration["UserID"];
conStrBuilder.Password = builder.Configuration["Password"];
conStrBuilder.Encrypt = false;
// ^^^
//https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/enable-encrypted-connections-to-the-database-engine?view=sql-server-ver16

Console.WriteLine("RECIPE CONNECTION STRING: " + conStrBuilder.ConnectionString);

// https://youtu.be/QPelWd9L9ck Alternative

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContextFactory<Recipe.Data.Context, Recipe.API.DbContextFactory>();

builder.Services
    .AddMultiTenant<TenantInfo>()
        .WithHeaderStrategy()
        .WithConfigurationStore();

builder.Services.AddGraphQLServer()
    // .AddConfiguration()
    .AddQueryType<Recipe.API.GraphQL.RecipeQuery>()
    .AddMutationType<Recipe.API.GraphQL.Mutation>()
    .AddQueryableCursorPagingProvider(default!, true)
    .AddFiltering()
    .AddProjections()
    .AddSorting();
    //.AddDbContext
    //.RegisterDbContextFactory
    //.RegisterDbContext<Recipe.Data.Context>(DbContextKind.Pooled);

// https://github.com/dotnet/efcore/pull/28708/

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

app.UseRouting();

app.UseMultiTenant();

app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions() {
    GraphQLEndPoint = "/graphql"
});

app.Run();
