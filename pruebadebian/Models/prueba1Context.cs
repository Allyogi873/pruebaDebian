using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pruebadebian.Models
{
    public partial class prueba1Context : DbContext
    {
        public prueba1Context()
        {
        }

        public prueba1Context(DbContextOptions<prueba1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("uid=root;password=A50568613;server=127.0.0.1;port=3306;database=prueba1;sshHostName=192.168.0.7;sshUserName=allan;sshPassword=A50568613");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.CodAnimal)
                    .HasName("PRIMARY");

                entity.ToTable("animal");

                entity.Property(e => e.CodAnimal).HasColumnName("cod_animal");

                entity.Property(e => e.Alimentacion)
                    .HasColumnName("alimentacion")
                    .HasMaxLength(45);

                entity.Property(e => e.Especie)
                    .HasColumnName("especie")
                    .HasMaxLength(45);

                entity.Property(e => e.Habitat)
                    .HasColumnName("habitat")
                    .HasMaxLength(45);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
