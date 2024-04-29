using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ClassScheduler.Infrastructure.Authentication;
public class TokenProviderService : ITokenProviderService
{
    private readonly string _key;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly string _expiryMinutes;
    public TokenProviderService(string key, string issueer, string audience, string expiryMinutes)
    {
        _key = key;
        _issuer = issueer;
        _audience = audience;
        _expiryMinutes = expiryMinutes;
    }
    public async Task<string> GenerateJWTTokenAsync(User userDetails)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new (CustomClaims.UserId, userDetails.Id),
            new(JwtRegisteredClaimNames.Sub, userDetails.UserName),
            new(JwtRegisteredClaimNames.Jti, userDetails.PersonInfo.FirstName)
        };

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_expiryMinutes)),
            signingCredentials: signingCredentials
       );
        var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
        return encodedToken;
    }
}

