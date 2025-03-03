using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using University_API.Models;

namespace University_API.Services;

public class TokenService
{
    public string GenerateToken(Administrador adm)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("id", adm.Id),
            new Claim("username", adm.UserName),
            new Claim(ClaimTypes.DateOfBirth, adm.DataNasc.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("n5fCsGTr984nf9Gi8967N9J9jsVF7SG1Pk9B1"));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signingCredentials
            );


        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
