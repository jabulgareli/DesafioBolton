using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBolton.Bolton.Domain.Core.NFes.ValueObjects
{
    public class ImportProfile
    {
        public Guid Id { get; set; }
        public string CurrentPage { get; set; }

        public ImportProfile()
        {
            Id = Guid.NewGuid();
        }
    
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
