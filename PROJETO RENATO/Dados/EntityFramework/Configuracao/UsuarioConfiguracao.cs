using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Dados.EntityFramework.Configuracao
{
    public class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Ignore(f => f.SenhaVerificacao);

            builder.ToTable("Usuario", "db_AppAdministrativo");
            builder.HasKey("UsuarioId");
            builder.Property(t => t.UsuarioId).HasColumnName("UsuarioId").HasColumnType("int");
            builder.Property(t => t.UsuarioAcesso).HasColumnName("UsuarioAcesso").HasColumnType("string");
            builder.Property(t => t.SenhaAcesso).HasColumnName("SenhaAcesso").HasColumnType("string");
            builder.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("string");


        }
    }
}
