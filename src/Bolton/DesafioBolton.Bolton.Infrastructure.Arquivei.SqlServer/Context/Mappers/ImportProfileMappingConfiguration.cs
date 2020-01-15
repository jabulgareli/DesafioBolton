using DesafioBolton.Bolton.Domain.Core.NFes.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBolton.Bolton.Infrastructure.Arquivei.SqlServer.Context.Mappers
{
    public class ImportProfileMappingConfiguration : IEntityTypeConfiguration<ImportProfile>
    {
        public void Configure(EntityTypeBuilder<ImportProfile> builder)
        {
            builder.ToTable("IMPORT_PROFILE");
            builder.HasKey(i => i.Id);
        }
    }
}
