using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Dados.EntityFramework.Configuracao
{
    public class ImplementacaoConfiguracao : IEntityTypeConfiguration<Implementacao>
    {
        public void Configure(EntityTypeBuilder<Implementacao> builder)
        {
            builder.ToTable("Implementacao", "db_AppAdministrativo");
            builder.HasKey("IdImplementacao");
            builder.Property(t => t.IdImplementacao).HasColumnName("IdImplementacao").HasColumnType("int");
            builder.Property(t => t.Valor).HasColumnName("Valor").HasColumnType("string");
            builder.Property(t => t.Tempo).HasColumnName("Tempo").HasColumnType("string");
            builder.Property(t => t.NomeSistema).HasColumnName("NomeSistema").HasColumnType("int");
            builder.Property(t => t.TipoDseSistema).HasColumnName("TipoDeSistema").HasColumnType("int");
        }
    }
}
