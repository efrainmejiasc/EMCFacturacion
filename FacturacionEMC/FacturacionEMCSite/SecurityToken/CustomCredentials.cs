
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;

namespace FacturacionEMCSite.SecurityToken
{
    public class CustomCredentials : ServiceClientCredentials
    {
        private string AuthenticationToken { get; set; }

        public override void InitializeServiceClient<T>(ServiceClient<T> client)
        {

            // Obtiene la identidad actual
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;

            // Get the claims values
            var accessToken = identity.Claims.Where(c => c.Type == "access_token")
                               .Select(c => c.Value).SingleOrDefault();

            //Valida si existe token, entonces agrega la cabecera
            if (accessToken != null)
                client.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            AuthenticationToken = accessToken;
        }

    }
}