using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Dados.EntityFramework.Configuracao
{
    public class SuporteConfiguracao : IEntityTypeConfiguration<Suporte>
    {
        public void Configure(EntityTypeBuilder<Suporte> builder)
        {
            builder.ToTable("Suporte", "db_AppAdministrativo");
            builder.HasKey("IdSuporte");
            
            builder.Property(t => t.IdSuporte)
                   .HasColumnName("IdSuporte")
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(t => t.NomeDoAtendente)
                   .HasColumnName("NomeDoAtendente")
                   .HasColumnType("string")
                   .IsRequired();

            builder.Property(t => t.TipoDeProblema)
                   .HasColumnName("TipoDeProblema")
                   .HasColumnType("string")
                   .IsRequired();
                   
            builder.Property(t => t.AvaliacaoDoCliente)
                   .HasColumnName("AvaliacaoDoCliente")
                   .HasColumnType("int")
                   .IsRequired();
        }
    }
}
