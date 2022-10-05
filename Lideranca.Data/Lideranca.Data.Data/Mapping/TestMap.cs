using Lideranca.Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lideranca.Data.Data.Mapping
{
    public class TestMap : IEntityTypeConfiguration<TestEntity>
    {
        public void Configure(EntityTypeBuilder<TestEntity> builder)
        {

            builder.ToTable("Test");

            builder.HasKey(prop => prop.Id).HasName("Id");
            builder.Property(prop => prop.Id)
                   .HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(prop => prop.Text)
                    .HasConversion(prop => prop.ToString(), prop => prop)
                    .IsRequired()
                    .HasColumnName("Text")
                    .HasColumnType("nvarchar(max)");

            builder.Property(prop => prop.Observacao)
                    .HasConversion(prop => prop.ToString(), prop => prop)
                    .HasColumnName("Observacao")
                    .HasColumnType("nvarchar(max)");

            builder.Property(prop => prop.DateRegister)
                    .HasConversion(prop => prop, prop => prop)
                    .IsRequired()
                    .HasColumnName("DateRegister")
                    .HasColumnType("datetime2(7)");

            builder.Property(prop => prop.DateLastUpdate)
                    .HasConversion(prop => prop, prop => prop)
                    .IsRequired()
                    .HasColumnName("DateLastUpdate")
                    .HasColumnType("datetime2(7)");

        }
    }
}
