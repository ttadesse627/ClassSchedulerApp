using System.Security.Claims;
using System.Text;
using ClassScheduler.Application;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Infrastructure;
using ClassScheduler.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

string _issuer = builder.Configuration["Jwt:Issuer"]!;
string _audience = builder.Configuration["Jwt:Audience"]!;
string _key = builder.Configuration["Jwt:Key"]!;
string _expiryMinutes = builder.Configuration["Jwt:ExpiryMinutes"]!;

// Add services to the container.
builder.WebHost.UseUrls("http://127.0.0.1:8080");
builder.Services.AddControllers();

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(bearer =>
{
    bearer.RequireHttpsMetadata = false;
    bearer.SaveToken = true;
    bearer.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = _issuer,
        ValidAudience = _audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)),
        ClockSkew = TimeSpan.FromMinutes(Convert.ToDouble(_expiryMinutes)),
        NameClaimType = ClaimTypes.NameIdentifier
    };
});
builder.Services.AddSingleton<ITokenProviderService>(new TokenProviderService(_key, _issuer, _audience, _expiryMinutes));
builder.Services.AddAuthorization();
builder.Services.AddApplication(builder.Configuration)
                .AddInfrastructure(builder.Configuration);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
      policy =>
      {
          policy.WithOrigins("http://127.0.0.1:3000");
      }
    );
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
 
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
