using Application.Users.DTO.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.AuthorizationTokens;

public static class AuthOptions
{
    private const string ISSUER = "DeathmatchServer";
    private const string AUDIENCE = "DeathmatchClient";
    private const string KEY = "mysupersecret_secretkey!123";
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }

    public static TokenValidationParameters CreateValidationParameters()
    {
        return new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidIssuer = ISSUER,
            ValidateAudience = false,
            ValidAudience = AUDIENCE,
            ValidateLifetime = false,
            IssuerSigningKey = GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero
        };
    }

    public static ClaimsIdentity CreateClaimsIdentity(ViewUserDTO user)
    {
        return NewClaimsIdentity(user, "User");
    }

    public static ClaimsIdentity CreateClaimsIdentity(ViewUserDTO user, string token)
    {
        return NewClaimsIdentity(user, $"User: {token}");
    }

    private static ClaimsIdentity NewClaimsIdentity(ViewUserDTO user, string userName)
    {
        return new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role.Name),
        }, "tokenAuthorization");
    }

    public static UserToken CreateUserToken(ViewUserDTO user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = AuthOptions.CreateClaimsIdentity(user),
            SigningCredentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        var response = new UserToken
        {
            Token = tokenHandler.WriteToken(token),
            UserName = user.Name
        };

        return response;
    }
}