using Microsoft.EntityFrameworkCore;
using StudyPlannerAPI.Data;
using StudyPlannerAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure Entity Framework with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the service layer
builder.Services.AddScoped<IStudyPlanService, StudyPlanService>();

// Add controllers to the service container
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// Map the controllers
app.MapControllers();

app.Run();
