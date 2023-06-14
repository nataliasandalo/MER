using Api.Control.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;

namespace Api.Control.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<TbPortal> TbPortals { get; set; }

        public DbSet<TbMenu> TbMenus { get; set; }

        public DbSet<TbMenuItem> TbMenuItems { get; set; }

        public DbSet<TbServico> TbServicos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Configuração da tabela TbPortal
            builder.Entity<TbPortal>(entity =>
            {
                entity.HasKey(e => e.IdPortal);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DsFacebook)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DsInstagram)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DsYoutube)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DsTwitter)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            // Seed data para tabela TbPortal
            builder.Entity<TbPortal>().HasData(
                new TbPortal
                {
                    IdPortal = 1,
                    Status = 'A',
                    LogoHeader = null,
                    LogoFooter = null,
                    DsFacebook = "https://www.facebook.com",
                    DsInstagram = "https://www.instagram.com",
                    DsYoutube = "https://www.youtube.com",
                    DsTwitter = "https://www.twitter.com"
                },
                new TbPortal
                {
                    IdPortal = 2,
                    Status = 'A',
                    LogoHeader = null,
                    LogoFooter = null,
                    DsFacebook = "https://www.facebook.com",
                    DsInstagram = "https://www.instagram.com",
                    DsYoutube = "https://www.youtube.com",
                    DsTwitter = "https://www.twitter.com"
                }
            );

            // Configuração da tabela TbMenu
            builder.Entity<TbMenu>(entity =>
            {
                entity.HasKey(e => e.IdMenu);

                entity.Property(e => e.NmMenu)
                    .HasMaxLength(50);

                entity.Property(e => e.DsMenu)
                    .HasMaxLength(255);

                entity.HasOne(d => d.Portal)
                    .WithMany(p => p.TbMenus)
                    .HasForeignKey(d => d.IdPortal);
            });

            // Seed data para tabela TbMenu
            builder.Entity<TbMenu>().HasData(
                new TbMenu
                {
                    IdMenu = 1,
                    NmMenu = "Home",
                    DsMenu = "Página principal",
                    IdPortal = 1
                },
                new TbMenu
                {
                    IdMenu = 2,
                    NmMenu = "Sobre nós",
                    DsMenu = "Conheça mais sobre nossa empresa",
                    IdPortal = 1
                },
                new TbMenu
                {
                    IdMenu = 3,
                    NmMenu = "Produtos",
                    DsMenu = "Veja nossos produtos",
                    IdPortal = 2
                }
            );

            // Seeds
            builder.Entity<TbMenu>().HasData(
                new TbMenu { IdMenu = 1, NmMenu = "Menu 1", DsMenu = "Descrição do Menu 1", IdPortal = 1 },
                new TbMenu { IdMenu = 2, NmMenu = "Menu 2", DsMenu = "Descrição do Menu 2", IdPortal = 1 }
            );


            builder.Entity<TbMenuItem>()
                .HasKey(mi => new { mi.IdItem, mi.IdMenu, mi.IdServico });

            builder.Entity<TbMenuItem>()
                .HasOne(mi => mi.Menu)
                .WithMany(m => m.TbMenuItems)
                .HasForeignKey(mi => mi.IdMenu);

            builder.Entity<TbMenuItem>()
                .HasOne(mi => mi.Servico)
                .WithMany()
                .HasForeignKey(mi => mi.IdServico);

            builder.Entity<TbMenuItem>()
                .Property(mi => mi.Ordem)
                .IsRequired();

            builder.Entity<TbMenuItem>().HasData(
                new TbMenuItem { IdItem = 1, IdMenu = 1, IdServico = 1, Ordem = 1 },
                new TbMenuItem { IdItem = 2, IdMenu = 1, IdServico = 2, Ordem = 2 },
                new TbMenuItem { IdItem = 3, IdMenu = 2, IdServico = 3, Ordem = 1 }
            );

            builder.Entity<TbServico>().HasKey(s => s.IdServico);

            builder.Entity<TbServico>().Property(s => s.NmServico).HasMaxLength(50).IsRequired();
            builder.Entity<TbServico>().Property(s => s.DsServico).HasMaxLength(250);
            builder.Entity<TbServico>().Property(s => s.Link).HasMaxLength(250);

            builder.Entity<TbServico>().HasMany(s => s.MenuItems).WithOne(m => m.Servico).HasForeignKey(m => m.IdServico);

            builder.Entity<TbServico>().HasData(
                new TbServico { IdServico = 1, NmServico = "Serviço 1", DsServico = "Descrição do Serviço 1", Link = "http://servico1.com", Status = 'A' },
                new TbServico { IdServico = 2, NmServico = "Serviço 2", DsServico = "Descrição do Serviço 2", Link = "http://servico2.com", Status = 'A' },
                new TbServico { IdServico = 3, NmServico = "Serviço 3", DsServico = "Descrição do Serviço 3", Link = "http://servico3.com", Status = 'I' }
            );


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
