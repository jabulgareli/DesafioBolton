using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBolton.Bolton.Domain.Core.NFes.Aggregates
{
    public class NFe
    {
        public string AccessKey { get; private set; }
        public decimal Amount { get; private set; }

        public NFe(string accessKey, decimal amount)
        {
            AccessKey = accessKey;
            Amount = amount;
        }
    }
}
