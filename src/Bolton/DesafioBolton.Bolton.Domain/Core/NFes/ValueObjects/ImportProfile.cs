using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBolton.Bolton.Domain.Core.NFes.ValueObjects
{
    public class ImportProfile
    {
        public string CurrentPage { get; set; }
    
        public static ImportProfile CreateEmpty()
        {
            return new ImportProfile
            {
                CurrentPage = null
            };
        }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(CurrentPage);
        }
    }
}
