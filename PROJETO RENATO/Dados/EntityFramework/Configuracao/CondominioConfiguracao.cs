using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Dados.EntityFramework.Configuracao
{
    public class CondominioConfiguracao : IEntityTypeConfiguration<Condominio>
    {
        public void Configure(EntityTypeBuilder<Condominio> builder)
        {
            builder.ToTable("Condominio", "db_AppAdministrativo");
            builder.HasKey("IdCondominio");
            builder.Property(t => t.IdCondominio).HasColumnName("IdCondominio").HasColumnType("int");
            builder.Property(t => t.NomeCondominio).HasColumnName("NomeCondominio").HasColumnType("string");
            builder.Property(t => t.Cnpj).HasColumnName("Cnpj").HasColumnType("string");
            builder.Property(t => t.Endereco).HasColumnName("Endereco").HasColumnType("string");
        }
    }
}
