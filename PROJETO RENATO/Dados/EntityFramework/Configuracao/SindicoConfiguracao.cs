using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Dados.EntityFramework.Configuracao
{
    public class SindicoConfiguracao : IEntityTypeConfiguration<Sindico>
    {
        public void Configure(EntityTypeBuilder<Sindico> builder)
        {
            builder.ToTable("Sindico", "db_AppAdministrativo");
            builder.HasKey("IdSindico");
            builder.Property(t => t.IdSindico).HasColumnName("IdSindico").HasColumnType("int");
            builder.Property(t => t.NomeSindico).HasColumnName("NomeSindico").HasColumnType("string");
            builder.Property(t => t.Endereco).HasColumnName("Endereco").HasColumnType("string");
            builder.Property(t => t.CPF).HasColumnName("CPF").HasColumnType("string");
            builder.Property(t => t.Email).HasColumnName("Email").HasColumnType("string");
            builder.Property(t => t.NomeCondominio).HasColumnName("NomeCondominio").HasColumnType("string");
            builder.Property(t => t.UF).HasColumnName("UF").HasColumnType("string");
        }
    }
}

