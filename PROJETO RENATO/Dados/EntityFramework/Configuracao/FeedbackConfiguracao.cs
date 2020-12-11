using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Dados.EntityFramework.Configuracao
{
    public class FeedbackConfiguracao : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedback", "db_AppAdministrativo");
            builder.HasKey("IdFeedback");
            builder.Property(t => t.IdFeedback).HasColumnName("IdFeedback").HasColumnType("int");
            builder.Property(t => t.NomeCondominio).HasColumnName("NomeCondominio").HasColumnType("string");
            builder.Property(t => t.NomeMorador).HasColumnName("NomeMorador").HasColumnType("string");
            builder.Property(t => t.Reclamacao).HasColumnName("Reclamacao").HasColumnType("string");
        }
    }
}
