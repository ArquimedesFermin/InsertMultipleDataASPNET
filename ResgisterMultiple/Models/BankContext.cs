using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ResgisterMultiple.Models
{
    public partial class BankContext : DbContext
    {
        public BankContext()
            : base("name=BankContext")
        {
        }

        public virtual DbSet<departament> departaments { get; set; }
        public virtual DbSet<SucuDepar> SucuDepars { get; set; }
        public virtual DbSet<sucursal> sucursals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<departament>()
                .Property(e => e.nameDepartaments)
                .IsUnicode(false);

            modelBuilder.Entity<departament>()
                .HasMany(e => e.SucuDepars)
                .WithOptional(e => e.departament)
                .HasForeignKey(e => e.idDepartaments);

            modelBuilder.Entity<sucursal>()
                .Property(e => e.nameSucursals)
                .IsUnicode(false);

            modelBuilder.Entity<sucursal>()
                .HasMany(e => e.SucuDepars)
                .WithOptional(e => e.sucursal)
                .HasForeignKey(e => e.idSucursals);
        }
    }
}
