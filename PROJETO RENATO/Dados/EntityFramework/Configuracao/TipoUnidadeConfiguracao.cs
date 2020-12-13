using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Dados.EntityFramework.Configuracao
{
    public class TipoUnidadeConfiguracao : IEntityTypeConfiguration<TipoUnidade>
    {
        public void Configure(EntityTypeBuilder<TipoUnidade> builder)
        {
            builder.ToTable("TipoUnidade", "db_AppAdministrativo");
            builder.HasKey("TipoUnidadeID");
            builder.Property(t => t.TipoUnidadeID).HasColumnName("TipoID").HasColumnType("int");
            builder.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("string");
        }
    }
}
