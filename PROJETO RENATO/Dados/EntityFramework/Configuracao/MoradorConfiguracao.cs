using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Dados.EntityFramework.Configuracao
{
    public class MoradorConfiguracao : IEntityTypeConfiguration<Morador>
    {
        public void Configure(EntityTypeBuilder<Morador> builder)
        {
            builder.ToTable("Morador", "db_AppAdministrativo");
            builder.HasKey("IdMorador");
            builder.Property(t => t.IdMorador).HasColumnName("IdMorador").HasColumnType("int");
            builder.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("string");
            builder.Property(t => t.CPF).HasColumnName("CPF").HasColumnType("string");
            builder.Property(t => t.Email).HasColumnName("Email").HasColumnType("string");

        }
    }
}
