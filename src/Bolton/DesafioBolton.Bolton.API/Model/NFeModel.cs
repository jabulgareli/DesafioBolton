using DesafioBolton.Bolton.Domain.Core.NFes.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBolton.Bolton.API.Model
{
    public class NFeModel
    {
        public decimal Amount { get; set; }

        public static NFeModel FromNFe(NFe nfe)
        {
            return new NFeModel
            {
                Amount = nfe.Amount
            };
        }
    }
}
