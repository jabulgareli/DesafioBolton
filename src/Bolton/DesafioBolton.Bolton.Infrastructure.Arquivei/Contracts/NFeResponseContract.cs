using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBolton.Bolton.Infrastructure.Arquivei.Contracts
{
    public class NFeResponseContract
    {
        public Status Status { get; set; }
        public IList<PlainNFe> Data { get; set; }
        public Page Page { get; set; }
        public int Count { get; set; }
        public string Signature { get; set; }
    }

    public class Status
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }

    public class Page
    {
        public string Next { get; set; }
        public string Previous { get; set; }
    }

    public class PlainNFe
    {
        public string Access_key { get; set; }
        public string Xml { get; set; }
    }

}
