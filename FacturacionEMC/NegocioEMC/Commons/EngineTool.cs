﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    }
}
