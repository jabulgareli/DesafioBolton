using DesafioBolton.Bolton.Domain.Core.NFes.Aggregates;
using DesafioBolton.Bolton.Domain.Core.NFes.ValueObjects;
using DesafioBolton.Bolton.Infrastructure.Arquivei.SqlServer.Context.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBolton.Bolton.Infrastructure.Arquivei.SqlServer.Context
{
    public class BoltonContext : DbContext
    {
        public virtual DbSet<NFe> NFes { get; set; }
        public virtual DbSet<ImportProfile> ImportProfiles { get; set; }

        public BoltonContext(DbContextOptions<BoltonContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NFeMappingConfiguration());
            modelBuilder.ApplyConfiguration(new ImportProfileMappingConfiguration());
        }
    }
}
