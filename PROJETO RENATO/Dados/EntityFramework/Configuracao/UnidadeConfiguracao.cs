using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Dados.EntityFramework.Configuracao
{
    public class UnidadeConfiguracao : IEntityTypeConfiguration<Unidade>
    {
        public void Configure(EntityTypeBuilder<Unidade> builder)
        {
            builder.ToTable("Unidade", "db_AppAdministrativo");
            builder.HasKey("IdUnidade");
            builder.Property(t => t.IdUnidade).HasColumnName("IdUnidade").HasColumnType("int");
            builder.Property(t => t.UnidadeTipoId).HasColumnName("UnidadeTipoId").HasColumnType("int");
            builder.Property(t => t.IdMorador).HasColumnName("IdMorador").HasColumnType("int");
            builder.Property(t => t.NumeroUnidade).HasColumnName("NumeroUnidade").HasColumnType("int");
            builder.Property(t => t.idCondominio).HasColumnName("idCondominio").HasColumnType("int");
        }
    }

}