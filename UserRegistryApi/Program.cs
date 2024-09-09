using Microsoft.EntityFrameworkCore;
using UserRegistryApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
string connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
if (connectionString == null || connectionString.Equals(""))
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}
Console.WriteLine($"---[DEBUG]--- connectionString: {connectionString}, connectionString == null: {connectionString == null}, connectionString.Equals(\"\") {connectionString.Equals("")}");
builder.Services.AddDbContext<UserRegistryContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", builder =>
    {
        builder.WithOrigins("https://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowReactApp");

app.Run();