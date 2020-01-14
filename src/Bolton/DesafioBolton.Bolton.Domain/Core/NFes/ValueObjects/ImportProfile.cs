using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBolton.Bolton.Domain.Core.NFes.ValueObjects
{
    public class ImportProfile
    {
        public int CurrentCursor { get; set; }
        private int Limit { get; set; }
    }
}
