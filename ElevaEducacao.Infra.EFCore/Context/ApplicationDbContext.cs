using ElevaEducacao.Domain;
using ElevaEducacao.Infra.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElevaEducacao.Infra.EFCore.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Escola> Escola { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyMappings();
            modelBuilder.ApplyVarcharConvention();
            modelBuilder.ApplyDateTimeConvention();
        }
    }
}
