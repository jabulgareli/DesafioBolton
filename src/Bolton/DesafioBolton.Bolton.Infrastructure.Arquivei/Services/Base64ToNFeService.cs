using DesafioBolton.Bolton.Domain.Core.NFes.Aggregates;
using DesafioBolton.Bolton.Infrastructure.Arquivei.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DesafioBolton.Bolton.Infrastructure.Arquivei.Services
{
    public static class Base64ToNFeService
    {
        public static NFe FromBase64(string base64)
        {
            if (string.IsNullOrEmpty(base64))
            {
                throw new ArgumentNullException(nameof(base64));
            }

            var xml = Encoding.UTF8.GetString(Convert.FromBase64String(base64));

            var xmlDoc = new XmlDocument();

            xmlDoc.LoadXml(xml);
            var infNfe = xmlDoc.DocumentElement["infNFe"] ?? xmlDoc.DocumentElement.FirstChild["infNFe"];
            var chave = infNfe.Attributes["Id"].Value.Replace("NFe", string.Empty);
            var vTot = infNfe["total"].FirstChild["vNF"].InnerText;

            return new NFe(chave, decimal.Parse(vTot));
        }
    }
}
