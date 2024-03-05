using ClassScheduler.Application;
using ClassScheduler.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.WebHost.UseUrls("http://localhost:5000");
builder.Services.AddControllers();

builder.Services.AddApplication(builder.Configuration)
                .AddInfrastructure(builder.Configuration);

// var myCorsPolicy = "_myAllowSpecificOrigins";

builder.Services.AddCors(options => {
  options.AddDefaultPolicy(
    policy => {
      policy.WithOrigins("http://localhost:3000");
    }
  );
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Class Scheduler API", Description = "Class Scheduler App", Version = "v1" });
});
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "Class Scheduler API V1");
});


app.UseHttpsRedirection();
app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());
app.UseAuthorization();
app.MapControllers();
app.Run();
