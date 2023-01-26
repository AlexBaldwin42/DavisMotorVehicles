namespace DavisMotorVehicles.Data
{
	using Microsoft.EntityFrameworkCore;
	using System.Data.Common;

	public class VehicleDatabaseContext : DbContext
	{
		public DbSet<Vehicle> Vehicles { get; set; }
		public DbSet<VehicleType> VehicleTypes { get; set; }
		public DbSet<Tire> Tires { get; set; }
		public DbSet<TireStatus> TireStatuses { get; set; }
		public string DbPath { get; set; }

		public VehicleDatabaseContext()
		{
			//var folder = Environment.SpecialFolder.LocalApplicationData;
			var path = Directory.GetCurrentDirectory();
			//var path = Environment.GetFolderPath(folder);
			DbPath = Path.Join(path, "Vehicles.db");
		}

		// The following configures EF to create a Sqlite database file in the
		// special "local" folder for your platform.
		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite($"Data Source={DbPath}");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Vehicle>()
				.HasKey(e => e.Id);
			modelBuilder.Entity<Vehicle>()
				.HasIndex(i => i.VinNumber)
				.IsUnique();
			modelBuilder.Entity<Vehicle>()
				.HasOne(i => i.VehicleType)
				.WithMany(i => i.Vehicles)
				.HasPrincipalKey(i => i.Id);

			modelBuilder.Entity<VehicleType>()
				.HasKey(e => e.Id);
			modelBuilder.Entity<VehicleType>()
				.HasMany(i => i.Vehicles)
				.WithOne(i => i.VehicleType);

			modelBuilder.Entity<Tire>()
				.HasKey(i => i.Id);
			modelBuilder.Entity<Tire>()
				.HasOne(i => i.Vehicle)
				.WithMany(i => i.Tires)
				.HasPrincipalKey(i => i.Id);
			modelBuilder.Entity<Tire>()
				 .HasOne(i => i.TireStatus)
				 .WithMany(i => i.Tires)
				 .HasPrincipalKey(i => i.Id);

			modelBuilder.Entity<TireStatus>()
				.HasKey(i => i.Id);
			modelBuilder.Entity<TireStatus>()
				.HasMany(e => e.Tires)
				.WithOne(e => e.TireStatus);
			modelBuilder.Entity<TireStatus>()
						   .HasData(
						   new TireStatus() { Status = "Bad" },
						   new TireStatus() { Status = "Ok" },
						   new TireStatus() { Status = "Good" },
						   new TireStatus() { Status = "Great" }
				);


		}
	}
}