using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NegocioEMC.Commons
{
    public class EngineTool
    {
        public static string EnCodeBase64(string cadena)
        {
            var bytes = Encoding.UTF8.GetBytes(cadena);
            return Convert.ToBase64String(bytes);
        }

        public static string DecodeBase64(string cadena)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(cadena);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static Guid CreateUniqueidentifier()
        {
            Guid g = CreateGuid();
            if (g == Guid.Empty)
                g = CreateUniqueidentifier();

            return g;
        }

        private static Guid CreateGuid()
        {
            return Guid.NewGuid();
        }

        public static bool CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                return true;
            }

            return false;
        }

        public static void CreateFolder(string rootPath, string folder, string identificador)
        {
            CreateDirectory(rootPath + folder    + identificador);
        }

        public static bool EmailEsValido(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            bool resultado = false;
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    resultado = true;
                }
            }
            return resultado;
        }


        public static string SetSerieCartonBingo (int numero)
        {
            var resultado = string.Empty;

            if (numero >= 0 && numero <= 99) {
                var ceros = numero > 9 ? "00" : "000";
                resultado = "A-" + ceros + numero.ToString(); 
            }
            else if (numero >= 100 && numero <= 199) { resultado = "B-" + "0" + numero.ToString(); }
            else if (numero >= 200 && numero <= 299) { resultado = "C-" + "0" + numero.ToString(); }
            else if (numero >= 300 && numero <= 399) { resultado = "D-" + "0" + numero.ToString(); }
            else if (numero >= 400 && numero <= 499) { resultado = "E-" + "0" + numero.ToString(); }
            else if (numero >= 500 && numero <= 599) { resultado = "F-" + "0" + numero.ToString(); }
            else if (numero >= 600 && numero <= 699) { resultado = "G-" + "0" + numero.ToString(); }
            else if (numero >= 700 && numero <= 799) { resultado = "H-" + "0" + numero.ToString(); }
            else if (numero >= 800 && numero <= 899) { resultado = "I-" + "0" + numero.ToString(); }
            else if (numero >= 900 && numero <= 999) { resultado = "J-" + "0" + numero.ToString(); }

            if (string.IsNullOrEmpty(resultado))
                SetSerieCartonBingo(numero);

            return resultado;

        }
    }
}
