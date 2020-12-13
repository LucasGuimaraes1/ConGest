using Microsoft.EntityFrameworkCore;
using PROJETO_RENATO.Dados.EntityFramework.Configuracao;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Dados.EntityFramework.Comum
{
    public class Contexto : DbContext
    {
        public DbSet<EmpresaCliente> EmpresaCliente { get; set; }
        public DbSet<EmpresaImplementadora> EmpresaImplementadora { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Implementacao> Implementacao { get; set; }
        public DbSet<Sindico> Sindico { get; set; }
        public DbSet<Suporte> Suporte { get; set; }
        public DbSet<SuporteClone> SuporteClone { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Condominio> Condominio { get; set; }
        public DbSet<Morador> Morador { get; set; }
        public DbSet<Unidade> Unidade { get; set; }
        public DbSet<TipoUnidade> TipoUnidade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaClienteConfiguracao());
            modelBuilder.ApplyConfiguration(new EmpresaImplementadoraConfiguracao());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguracao());
            modelBuilder.ApplyConfiguration(new ImplementacaoConfiguracao());
            modelBuilder.ApplyConfiguration(new SindicoConfiguracao());
            modelBuilder.ApplyConfiguration(new SuporteCloneConfiguracao());
            modelBuilder.ApplyConfiguration(new SuporteConfiguracao());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracao());
            modelBuilder.ApplyConfiguration(new CondominioConfiguracao());
            modelBuilder.ApplyConfiguration(new MoradorConfiguracao());
            modelBuilder.ApplyConfiguration(new UnidadeConfiguracao());
            modelBuilder.ApplyConfiguration(new TipoUnidadeConfiguracao());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseSqlServer(@"Data source = 201.62.57.93;
                                          database = dbPICC_20202;
                                          user id = laboratorio;
                                          password = @laboratorio*;");
        }
    }
}
