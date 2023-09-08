using WeOwnAPI.Extensions;
using AutoMapper;
using WeOwnAPI.Helpers;
using WeOwnDomain.Database;
using Microsoft.EntityFrameworkCore;
using WeOwnInfra.SeedData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Entity Framework Configuration
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WeOwnContext>(options =>
    options.UseSqlServer(connectionString));


//ApplicationServices Configuration
builder.Services.AddApplicationServices();

// AutoMapper Configuration 
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // Dobijanje DbContext-a
        var context = services.GetRequiredService<WeOwnContext>();

        await WeOwnContextSeed.SeedAsync(context);
        // Ovde možete raditi šta god želite sa context-om
    }
    catch (Exception ex)
    {
        // Obrada greške ako dođe do problema pri dobijanju DbContext-a
    }
}


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
