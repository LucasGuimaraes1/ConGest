using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Dados.EntityFramework.Configuracao
{
    public class SuporteCloneConfiguracao : IEntityTypeConfiguration<SuporteClone>
    {
        public void Configure(EntityTypeBuilder<SuporteClone> builder)
        {
            builder.ToTable("SuporteClone", "db_AppAdministrativo");
            builder.HasKey("IdSuporteClone");
            builder.Property(t => t.IdSuporteClone).HasColumnName("IdSuporteClone").HasColumnType("int");
            builder.Property(t => t.NomeDoAtendente).HasColumnName("NomeDoAtendente").HasColumnType("string");
            builder.Property(t => t.TipoDeProblema).HasColumnName("TipoDeProblema").HasColumnType("string");
            builder.Property(t => t.AvaliacaoDoCliente).HasColumnName("AvaliacaoDoCliente").HasColumnType("int");
        }
    }
}
