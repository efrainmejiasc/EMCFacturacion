
using EMCApi.Client;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FacturacionEMCSite.SecurityToken
{
    public class JwtProvider
    {
        private static ClientEMCApi _clienteAPI;

        //default constructor
        public JwtProvider() { }

        public static JwtProvider Create(ClientEMCApi clienteAPI)
        {
            _clienteAPI = clienteAPI;
            return new JwtProvider();
        }

        public async Task<AccessToken> GetTokenAsync(CredencialesDTO credenciales)//, string clientId, string deviceId)
        {
            return await _clienteAPI.LoginAsync(credenciales);
        }

        private JObject DecodePayload(string token)
        {
            var parts = token.Split('.');
            var payload = parts[1];

            var payloadJson = Encoding.UTF8.GetString(Base64UrlDecode(payload));

            return JObject.Parse(payloadJson);
        }

        public ClaimsIdentity CreateIdentity(string accessToken)
        {
            //decode payload
            dynamic payload = this.DecodePayload(accessToken);

            var jwtIdentity = new ClaimsIdentity();
            try
            {
                jwtIdentity = new ClaimsIdentity(new JwtIdentity(true, payload.unique_name.ToObject(typeof(string)), "ApplicationCookie"));

                //add user id
                jwtIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, payload.nameid.ToObject(typeof(string))));
                jwtIdentity.AddClaim(new Claim(ClaimTypes.Name, payload.unique_name.ToObject(typeof(string))));
                jwtIdentity.AddClaim(new Claim(ClaimTypes.Role, payload.role.ToObject(typeof(string))));
                jwtIdentity.AddClaim(new Claim(ClaimTypes.Email, payload.email.ToObject(typeof(string))));
                jwtIdentity.AddClaim(new Claim("access_token", accessToken.Replace("\"", string.Empty)));
            }
            catch (Exception ex)
            {
                var exc = ex.ToString();
            }
         

            return jwtIdentity;
        }

        private byte[] Base64UrlDecode(string input)
        {
            var output = input;
            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding
            switch (output.Length % 4) // Pad with trailing '='s
            {
                case 0: break; // No pad chars in this case
                case 2: output += "=="; break; // Two pad chars
                case 3: output += "="; break; // One pad char
                default: throw new System.Exception("Illegal base64url string!");
            }
            var converted = Convert.FromBase64String(output); // Standard base64 decoder
            return converted;
        }

    }


    public class JwtIdentity : IIdentity
    {
        private bool _isAuthenticated;
        private string _name;
        private string _authenticationType;

        public JwtIdentity() { }
        public JwtIdentity(bool isAuthenticated, string name, string authenticationType)
        {
            _isAuthenticated = isAuthenticated;
            _name = name;
            _authenticationType = authenticationType;
        }
        public string AuthenticationType
        {
            get
            {
                return _authenticationType;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return _isAuthenticated;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }
    }
}