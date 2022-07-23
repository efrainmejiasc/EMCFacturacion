using DatosEMC.DTOs;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionEMCApi.SecurityToken 
{ 
    /// <summary>
    /// Clase del provedor de token
    /// </summary>
public class TokenProvider
    {

        private readonly JwtBearerTokenSettings _jwtBearerTokenSettings;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="jwtTokenOptions">Opciones de configuracion</param>
        public TokenProvider(JwtBearerTokenSettings jwtTokenOptions)
        {
            this._jwtBearerTokenSettings = jwtTokenOptions;
        }

        /// <summary>
        /// General el token de autenticacion
        /// </summary>
        /// <param name="usuarioDTO"></param>
        /// <param name="externo"></param>
        /// <returns></returns>
        public AccessToken GenerarToken(UsuarioDTO usuarioDTO,bool externo=false)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtBearerTokenSettings.SecretKey);
            var tokenString = string.Empty;
            var exp = 0;

            try
            {
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(new Claim[]
         {
                new Claim(ClaimTypes.NameIdentifier, usuarioDTO.Id.ToString() ?? string.Empty),
                new Claim(ClaimTypes.Name, usuarioDTO.Username ?? string.Empty),
                new Claim(ClaimTypes.Role, usuarioDTO.IdRol.ToString()?? "2"),
                new Claim(ClaimTypes.Email, usuarioDTO.Email ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
         });


                //claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, usuarioDTO.IdRol.ToString()));


                exp = (externo) ? _jwtBearerTokenSettings.ExpiryTimeInMinutes : _jwtBearerTokenSettings.ExpiryTimeInDays;
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claimsIdentity,
                    NotBefore = DateTime.UtcNow,
                    Audience = _jwtBearerTokenSettings.Audience,
                    Issuer = _jwtBearerTokenSettings.Issuer,
                    Expires = (externo) ? DateTime.UtcNow.AddMinutes(_jwtBearerTokenSettings.ExpiryTimeInMinutes) : DateTime.UtcNow.AddDays(_jwtBearerTokenSettings.ExpiryTimeInDays),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                tokenString = tokenHandler.WriteToken(token);
            }
            catch(Exception  ex)
            {
                var error = ex.ToString();
            }

         
            return new AccessToken(tokenString, exp, externo);

        }

       
     
    }
}
