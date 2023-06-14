using Api.Servico.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;

namespace Api.Servico.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<TbSolicitarFerias> TbSolicitarFerias { get; set; }
        public DbSet<TbContrato> TbContratos { get; set; }
        public DbSet<TbStatus> TbStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Configuração da tabela TbSolicitarFerias
            builder.Entity<TbSolicitarFerias>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.DataInicial).IsRequired();
                entity.Property(e => e.DataFim).IsRequired();
                entity.Property(e => e.NumeroDias).IsRequired();
                entity.Property(e => e.DiasAbono).IsRequired();

                entity.HasOne(d => d.TbContratos)
                    .WithMany(p => p.TbSolicitarFerias)
                    .HasForeignKey(d => d.IdContrato)
                    .IsRequired();

                entity.HasOne(d => d.TbStatus)
                    .WithMany(p => p.TbSolicitarFerias)
                    .HasForeignKey(d => d.IdStatus)
                    .IsRequired();
            });

            // Seed data para tabela TbSolicitarFerias
            builder.Entity<TbSolicitarFerias>().HasData(
                new TbSolicitarFerias
                {
                    Id = 1,
                    DataInicial = new DateTime(2022, 01, 01),
                    DataFim = new DateTime(2022, 01, 15),
                    NumeroDias = 15,
                    DiasAbono = 0,
                    IdStatus = 1,
                    IdContrato = 1
                },
                new TbSolicitarFerias
                {
                    Id = 2,
                    DataInicial = new DateTime(2022, 02, 01),
                    DataFim = new DateTime(2022, 02, 15),
                    NumeroDias = 15,
                    DiasAbono = 0,
                    IdStatus = 1,
                    IdContrato = 1
                }
            );

            // Configuração da tabela TbContrato
            builder.Entity<TbContrato>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CodContrato).HasMaxLength(50);
                entity.Property(e => e.NmContrato).HasMaxLength(250);
                entity.Property(e => e.DSContrato).HasMaxLength(250);

                entity.HasMany(d => d.TbSolicitarFerias)
                    .WithOne(p => p.TbContratos)
                    .HasForeignKey(d => d.IdContrato)
                    .IsRequired();
            });

            // Seeds
            builder.Entity<TbContrato>().HasData(
                new TbContrato
                {
                    Id = 1,
                    CodContrato = "CT-001",
                    NmContrato = "Contrato 1",
                    DSContrato = "Descrição do contrato 1"
                },
                new TbContrato
                {
                    Id = 2,
                    CodContrato = "CT-002",
                    NmContrato = "Contrato 2",
                    DSContrato = "Descrição do contrato 2"
                }
            );

            // Configuração da tabela TbStatus
            builder.Entity<TbStatus>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.NmStatus).IsRequired().HasMaxLength(50);
                entity.Property(e => e.DsStatus).HasMaxLength(250);
            });

            // Configuração da tabela TbStatus
            builder.Entity<TbStatus>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.NmStatus).IsRequired().HasMaxLength(50);
                entity.Property(e => e.DsStatus).HasMaxLength(250);

                entity.HasMany(e => e.TbSolicitarFerias)
                    .WithOne(e => e.TbStatus)
                    .HasForeignKey(e => e.IdStatus)
                    .IsRequired();
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
