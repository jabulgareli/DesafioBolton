using DesafioBolton.Bolton.Infrastructure.Arquivei.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace DesafioBolton.Bolton.Infrastructure.Arquivei.Services
{
    public static class Base64ToNFeService
    {
        public static nfeProc FromBase64(string base64)
        {
            if (string.IsNullOrEmpty(base64))
            {
                throw new ArgumentNullException(nameof(base64));
            }

            var xmlSerializer = new XmlSerializer(typeof(nfeProc));

            var xml = Encoding.UTF8.GetString(Convert.FromBase64String(base64));

            using (var reader = new StringReader(xml))
            {
                return (nfeProc)xmlSerializer.Deserialize(reader);
            };
        }
    }
}
