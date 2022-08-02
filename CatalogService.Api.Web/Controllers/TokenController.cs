using CatalogService.Api.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Api.Web.Controllers
{

    [ApiController]
    public class TokenController : ControllerBase
    {
        // 1. Not best practice to hardcode any secrets in the code.
        // 2. DRY violation: duplicate to the value in Startup.cs
        private const string Secret = "this is my custom Secret key for authentication";

        // Returns an JWT token when the login info is valid.
        [Route("token")]
        [HttpPost()]
        public IActionResult GetToken([FromBody] UserContract login)
        {
            string accessToken = GetAccessToken(login);

            if (string.IsNullOrEmpty(accessToken))
            {
                return Forbid();
            }

            return Ok(new
            {
                token = accessToken,
            });
        }

        /// <summary>
        /// Returns an access token when the login is valid. Returns null otherwise;
        /// </summary>
        private string GetAccessToken(UserContract login)
        {
                JwtSecurityToken jwtSecurityToken = GetUserToken(login);
                return (new JwtSecurityTokenHandler()).WriteToken(jwtSecurityToken);
        }

        private JwtSecurityToken GetUserToken(UserContract login)
        {
            if (IsManagerValid(login) && IsBuyerValid(login))
            {
                JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                               issuer: "saar",
                               audience: "saar-audience",
                               claims: new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, login.UserName),
                    new Claim("whatever-I-want-to-put-here", "whatevervalue"),
                    new Claim(ClaimTypes.Role, "Manager"),
                    new Claim(ClaimTypes.Role, "Buyer")
                                   // Usually getting roles from database for the current user
                               },
                               expires: DateTime.UtcNow.AddMinutes(5),
                               signingCredentials: new SigningCredentials(
                                   key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret)),
                                   algorithm: SecurityAlgorithms.HmacSha256
                               )
                           );
                return jwtSecurityToken;
            }
            // Package: System.IdentityModel.Tokens.Jwt
            if (IsBuyerValid(login))
            {
                JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                               issuer: "saar",
                               audience: "saar-audience",
                               claims: new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, login.UserName),
                    new Claim("whatever-I-want-to-put-here", "whatevervalue"),
                    new Claim(ClaimTypes.Role, "Buyer")
                                   // Usually getting roles from database for the current user
                               },
                               expires: DateTime.UtcNow.AddMinutes(5),
                               signingCredentials: new SigningCredentials(
                                   key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret)),
                                   algorithm: SecurityAlgorithms.HmacSha256
                               )
                           );
                return jwtSecurityToken;
            }
            else 
            if (IsManagerValid(login))
            {
                JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                               issuer: "saar",
                               audience: "saar-audience",
                               claims: new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, login.UserName),
                    new Claim("whatever-I-want-to-put-here", "whatevervalue"),
                    new Claim(ClaimTypes.Role, "Manager"),
                                   // Usually getting roles from database for the current user
                               },
                               expires: DateTime.UtcNow.AddMinutes(5),
                               signingCredentials: new SigningCredentials(
                                   key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret)),
                                   algorithm: SecurityAlgorithms.HmacSha256
                               )
                           );
                return jwtSecurityToken;
            }

            JwtSecurityToken jwtGuestSecurityToken = new JwtSecurityToken(
                              issuer: "saar",
                              audience: "saar-audience",
                              claims: new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, login.UserName),
                    new Claim("whatever-I-want-to-put-here", "whatevervalue"),
                    new Claim(ClaimTypes.Role, "Guest"),
                                  // Usually getting roles from database for the current user
                              },
                              expires: DateTime.UtcNow.AddMinutes(5),
                              signingCredentials: new SigningCredentials(
                                  key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret)),
                                  algorithm: SecurityAlgorithms.HmacSha256
                              )
                          );
            return jwtGuestSecurityToken;
        }

        /// <summary>
        /// Verify if the user matches the record.
        /// </summary>
        /// <remarks>
        /// This is simplified. You probably need to compare the user credential with records in DB to determine if the user is valid or not.
        /// </remarks>
        private bool IsManagerValid(UserContract login)
            => string.Equals(login?.UserName, "Manager", StringComparison.OrdinalIgnoreCase) && string.Equals(login?.Password, "123", StringComparison.Ordinal);
        private bool IsBuyerValid(UserContract login)
           => string.Equals(login?.UserName, "Buyer", StringComparison.OrdinalIgnoreCase) && string.Equals(login?.Password, "123", StringComparison.Ordinal);
    }
}
