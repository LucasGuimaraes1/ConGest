using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Dados.EntityFramework.Configuracao
{
    public class EmpresaImplementadoraConfiguracao : IEntityTypeConfiguration<EmpresaImplementadora>
    {
        public void Configure(EntityTypeBuilder<EmpresaImplementadora> builder)
        {
            builder.ToTable("EmpresaImplementadora", "db_AppAdministrativo");
            builder.HasKey("IdEmpresaImplementadora");
            builder.Property(t => t.IdEmpresaImplementadora).HasColumnName("IdEmpresaImplementadora").HasColumnType("int");
            builder.Property(t => t.Endereco).HasColumnName("Endereco").HasColumnType("string");
            builder.Property(t => t.CNPJ).HasColumnName("Cnpj").HasColumnType("string");
            builder.Property(t => t.NomeProprietario).HasColumnName("NomeProprietario").HasColumnType("string");
            builder.Property(t => t.Cidade).HasColumnName("Cidade").HasColumnType("string");
            builder.Property(t => t.UF).HasColumnName("UF").HasColumnType("string");
        }
    }
}
