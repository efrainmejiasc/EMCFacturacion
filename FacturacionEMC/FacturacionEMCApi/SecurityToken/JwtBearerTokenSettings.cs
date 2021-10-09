using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionEMCApi.SecurityToken
{
    /// <summary>
    /// Configuracion para el JWT
    /// </summary>
    public class JwtBearerTokenSettings
    {
        /// <summary>
        /// Llave de encriptacion
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Solicitantes
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Gerador de token
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Tiempo de expiracion en dias
        /// </summary>
        public int ExpiryTimeInDays { get; set; }

        /// <summary>
        /// Tiempo de expiracion en minutos
        /// </summary>
        public int ExpiryTimeInMinutes { get; set; }
    }
}
