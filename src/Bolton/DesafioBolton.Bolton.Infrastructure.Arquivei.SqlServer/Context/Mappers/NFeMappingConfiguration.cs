using DesafioBolton.Bolton.Domain.Core.NFes.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBolton.Bolton.Infrastructure.Arquivei.SqlServer.Context.Mappers
{
    public class NFeMappingConfiguration : IEntityTypeConfiguration<NFe>
    {
        public void Configure(EntityTypeBuilder<NFe> builder)
        {
            builder.ToTable("NFE");

            builder.HasKey(nfe => nfe.AccessKey);
        }
    }
}
