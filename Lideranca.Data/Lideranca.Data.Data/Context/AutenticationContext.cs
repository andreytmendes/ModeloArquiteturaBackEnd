using Lideranca.Data.Data.Mapping;
using Lideranca.Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lideranca.Data.Data.Context
{
    public class AutenticationContext : DbContext
    {
        public AutenticationContext(DbContextOptions<AutenticationContext> options) : base(options) { }

        public DbSet<TestEntity> TestEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.HasDefaultSchema("liderancadb");
            base.OnModelCreating(model);
            model.Entity<TestEntity>(new TestMap().Configure);

            //ConfigureTestEntity(model);
        }

        //private void ConfigureTestEntity(ModelBuilder construtorDeModelos)
        //{
        //    construtorDeModelos.Entity<TestEntity>(x =>
        //    {
        //        x.ToTable("Test");
        //        x.HasKey(c => c.Id).HasName("Id");
        //        x.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
        //        x.Property(c => c.Text).HasColumnName("Text").IsRequired().HasMaxLength(100000);
        //        x.Property(c => c.DateRegister).HasColumnName("DateRegister").IsRequired();
        //        x.Property(c => c.DateLastUpdate).HasColumnName("DateLastUpdate").IsRequired();
        //    });
        //}
    }
}
