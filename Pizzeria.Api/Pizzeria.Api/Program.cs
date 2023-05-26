using Pizzeria.Business.Services;
using Pizzeria.Repository;

var builder = WebApplication.CreateBuilder(args);

// Cors setup
const string CorsPolicyName = "PizzeriaCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicyName, builder =>
    {
        builder
            .WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Setting up dependency injection
builder.Services.AddSingleton<IPizzaRepository, PizzaRepository>();
builder.Services.AddSingleton<IRestaurantPizzaPriceRepository, RestaurantPizzaPriceRepository>();
builder.Services.AddSingleton<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddSingleton<IToppingRepository, ToppingRepository>();
builder.Services.AddSingleton<IPizzaService, PizzaService>();
builder.Services.AddSingleton<IRestaurantService, RestaurantService>();

var app = builder.Build();
app.UseCors(CorsPolicyName);

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
