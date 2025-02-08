using Application.Recipes.Common.Interfaces;
using Application.Recipes.Queries.GetRecipes;
using Infrastructure.Data;
using Infrastructure;
using maten_backend.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices();
builder.Services.AddOpenApi();
builder.Services.AddScoped(typeof(IRepositoryService<>), typeof(RepositoryService<>));
builder.Services.AddScoped(typeof(IRecipeService), typeof(RecipeService));
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(GetRecipesHandler).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.ConfigureEndpoints();
app.Run();
