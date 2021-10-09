using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionEMCSite.SecurityToken
{
    public class JwtToken
    {
        public int? nameid { get; set; }

        public string unique_name { get; set; }

        public string given_name { get; set; }

        public DateTime? nbf { get; set; }

        public DateTime? exp { get; set; }

        public DateTime? iat { get; set; }

        public string iss { get; set; }

        public string aud { get; set; }

        public string[] role { get; set; }

    }
}