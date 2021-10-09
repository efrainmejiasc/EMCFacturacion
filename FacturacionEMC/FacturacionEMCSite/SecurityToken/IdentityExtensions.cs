using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;


namespace FacturacionEMCSite
{
    /// <summary>
    /// Clase de extension para la identidad
    /// </summary>
    public static class IdentityExtensions
    {
        /// <summary>
        /// Obtiene el identificador de usuario
        /// </summary>
        /// <param name="identity">Identidad</param>
        /// <returns>Identificador del usuario</returns>
        public static int GetId(this IIdentity identity)
        {
            var claim = (identity as ClaimsIdentity)?.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
                return 0;
            return int.Parse(claim.Value);
        }

       

        /// <summary>
        /// Obtiene el nombre de usuario        
        /// </summary>
        /// <param name="identity">Identidad</param>
        /// <returns>Nombre de usuario</returns>
        public static string GetUsuario(this IIdentity identity)
        {
            var claim = (identity as ClaimsIdentity)?.FindFirst(ClaimTypes.Name);

            return claim != null ? claim.Value : string.Empty;
        }

        /// <summary>
        /// Obtiene el nombre de la persona
        /// </summary>
        /// <param name="identity">Identidad</param>
        /// <returns>Nombre de la persona</returns>
        public static string GetNombre(this IIdentity identity)
        {
            var claim = (identity as ClaimsIdentity)?.FindFirst(ClaimTypes.GivenName);

            return claim != null ? claim.Value : string.Empty;
        }

        /// <summary>
        /// Obtiene los apellidos de la persona 
        /// </summary>
        /// <param name="identity">Identidad</param>
        /// <returns>Apellidos del usuario</returns>
        public static string GetApellidos(this IIdentity identity)
        {
            var claim = (identity as ClaimsIdentity)?.FindFirst(ClaimTypes.Surname);

            return claim != null ? claim.Value : string.Empty;
        }

        /// <summary>
        /// Obtiene el correo electronico
        /// </summary>
        /// <param name="identity">Identidad</param>
        /// <returns>correo electronico del usuario</returns>
        public static string GetEmail(this IIdentity identity)
        {
            var claim = (identity as ClaimsIdentity)?.FindFirst(ClaimTypes.Email);

            return claim != null ? claim.Value : string.Empty;
        }

        /// <summary>
        /// Obtiene la lista de roles que tiene el usuario
        /// </summary>
        /// <param name="identity">Identidad</param>
        /// <returns>role</returns>
        public static List<string> GetRoles(this IIdentity identity)
        {
            List<string> roles = new List<string>();

            var claimRoles = (identity as ClaimsIdentity)?.FindAll(ClaimTypes.Role);

            foreach (var claim in claimRoles)
            {
                roles.Add(claim.Value);
            }

            return roles;
        }
    }
}