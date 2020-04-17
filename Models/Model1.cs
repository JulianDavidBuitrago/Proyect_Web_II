namespace ZOOLO.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class Model1 : DbContext
	{
		public Model1()
			: base("name=Model1")
		{
		}

		public virtual DbSet<Animal> Animal { get; set; }
		public virtual DbSet<Cita> Cita { get; set; }
		public virtual DbSet<Cliente> Cliente { get; set; }
		public virtual DbSet<Parqueadreo> Parqueadreo { get; set; }
		public virtual DbSet<ParqueadreoVehiculo> ParqueadreoVehiculo { get; set; }
		public virtual DbSet<Plans> Plans { get; set; }
		public virtual DbSet<PlansCliente> PlansCliente { get; set; }
		public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
		public virtual DbSet<Trabajador> Trabajador { get; set; }
		public virtual DbSet<Vehiculo> Vehiculo { get; set; }
		public virtual DbSet<Veterinario> Veterinario { get; set; }
		public virtual DbSet<Zona> Zona { get; set; }
		public virtual DbSet<Zoologico> Zoologico { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Animal>()
				.HasMany(e => e.Cita)
				.WithRequired(e => e.Animal)
				.HasForeignKey(e => e.IdAnimCita)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Cliente>()
				.HasMany(e => e.PlansCliente)
				.WithRequired(e => e.Cliente)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Parqueadreo>()
				.HasMany(e => e.ParqueadreoVehiculo)
				.WithRequired(e => e.Parqueadreo)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Plans>()
				.HasMany(e => e.PlansCliente)
				.WithRequired(e => e.Plans)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Vehiculo>()
				.HasMany(e => e.ParqueadreoVehiculo)
				.WithRequired(e => e.Vehiculo)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Veterinario>()
				.HasMany(e => e.Cita)
				.WithRequired(e => e.Veterinario)
				.HasForeignKey(e => e.IdVeteCita)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Zona>()
				.HasMany(e => e.Animal)
				.WithRequired(e => e.Zona)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Zona>()
				.HasMany(e => e.Trabajador)
				.WithRequired(e => e.Zona)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Zoologico>()
				.HasMany(e => e.Parqueadreo)
				.WithRequired(e => e.Zoologico)
				.HasForeignKey(e => e.IdZooPar)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Zoologico>()
				.HasMany(e => e.Plans)
				.WithRequired(e => e.Zoologico)
				.HasForeignKey(e => e.IdZooPlans)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Zoologico>()
				.HasMany(e => e.Zona)
				.WithRequired(e => e.Zoologico)
				.WillCascadeOnDelete(false);
		}
	}
}
