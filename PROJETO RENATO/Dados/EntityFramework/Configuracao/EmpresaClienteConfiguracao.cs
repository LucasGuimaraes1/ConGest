using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Dados.EntityFramework.Configuracao
{
    public class EmpresaClienteConfiguracao : IEntityTypeConfiguration<EmpresaCliente>
    {
        public void Configure(EntityTypeBuilder<EmpresaCliente> builder)
        {
            builder.ToTable("EmpresaCliente", "db_AppAdministrativo");
            builder.HasKey("IdEmpresaCliente");
            builder.Property(t => t.IdEmpresaCliente).HasColumnName("IdEmpresaCliente").HasColumnType("int");
            builder.Property(t => t.Endereco).HasColumnName("Endereco").HasColumnType("string");
            builder.Property(t => t.CNPJ).HasColumnName("Cnpj").HasColumnType("string");
            builder.Property(t => t.NomeProprietario).HasColumnName("NomeProprietario").HasColumnType("string");
            builder.Property(t => t.Cidade).HasColumnName("Cidade").HasColumnType("string");
            builder.Property(t => t.UF).HasColumnName("UF").HasColumnType("string");
        }
    }
}
