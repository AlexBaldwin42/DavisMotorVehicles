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
			var path = Directory.GetCurrentDirectory();
			path = Path.GetFullPath(Path.Combine(path, @"..\Data\"));
			DbPath = Path.Join(path, "Vehicles.db");
		}

		// The following configures EF to create a Sqlite database file in the
		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite($"Data Source={DbPath}");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TireStatus>()
			   .HasData(
				   new TireStatus() { Id = 1, Status = "Bad" },
				   new TireStatus() { Id = 2, Status = "Fair" },
				   new TireStatus() { Id = 3, Status = "Good" }
				);

			modelBuilder.Entity<VehicleType>()
				.HasData(
					new VehicleType() { Id = 1, Name = "Car", NumberOfTires = 4 },
					new VehicleType() { Id = 2, Name = "Truck", NumberOfTires = 4},
					new VehicleType() { Id = 3, Name = "Motorcycle", NumberOfTires = 2 },
					new VehicleType() { Id = 4, Name = "Boat", NumberOfTires = 0 }
				);

			modelBuilder.Entity<Vehicle>()
				.HasData(
					new Vehicle() { Id = 1, VehicleTypeId = 1, Make = "Dodge", Model = "Avenger", Year = 2013, VinNumber = "1C3CDZBG8DN504146", FuelLevel = 40 },// var dodge avenget
					new Vehicle() { Id = 2, VehicleTypeId = 1, Make = "Honda", Model = "CRV", Year = 2017, VinNumber = "5J6RM4850CL703159", FuelLevel = 50 },// car honda crv
					new Vehicle() { Id = 3, VehicleTypeId = 1, Make = "Acura", Model = "Integra", Year = 2018, VinNumber = "JH4KA3151LC012001", FuelLevel = 60 },//car acure
					new Vehicle() { Id = 4, VehicleTypeId = 2, Make = "Dodge", Model = "Ram1500", Year = 2011, VinNumber = "3B7KF23Z42M211215", FuelLevel = 70 },//dodge  Truck
					new Vehicle() { Id = 5, VehicleTypeId = 4, Make = "Tige", Model = "WakeMaster", Year = 2003, VinNumber = "848DKDIEKDL888DKD", FuelLevel = 80 },//Boat
					new Vehicle() { Id = 6, VehicleTypeId = 3, Make = "Honda", Model = "Shadow", Year = 2022, VinNumber = "KDEID3366DKDKDKIF", FuelLevel = 90 }//motorcycle
				);

			modelBuilder.Entity<Tire>()
				.HasData(
					new Tire() { Id = 1, VehicleId = 1, TireStatusId = 1 },
					new Tire() { Id = 2, VehicleId = 1, TireStatusId = 1 },
					new Tire() { Id = 3, VehicleId = 1, TireStatusId = 1 },
					new Tire() { Id = 4, VehicleId = 1, TireStatusId = 1 },
					new Tire() { Id = 5, VehicleId = 2, TireStatusId = 3 },
					new Tire() { Id = 6, VehicleId = 2, TireStatusId = 3 },
					new Tire() { Id = 7, VehicleId = 2, TireStatusId = 3 },
					new Tire() { Id = 8, VehicleId = 2, TireStatusId = 3 },
					new Tire() { Id = 9, VehicleId = 3, TireStatusId = 1 },
					new Tire() { Id = 10, VehicleId = 3, TireStatusId = 1 },
					new Tire() { Id = 11, VehicleId = 3, TireStatusId = 1 },
					new Tire() { Id = 12, VehicleId = 3, TireStatusId = 1 },
					new Tire() { Id = 13, VehicleId = 4, TireStatusId = 2 },
					new Tire() { Id = 14, VehicleId = 4, TireStatusId = 2 },
					new Tire() { Id = 15, VehicleId = 4, TireStatusId = 2 },
					new Tire() { Id = 16, VehicleId = 4, TireStatusId = 2 },
					new Tire() { Id = 17, VehicleId = 6, TireStatusId = 2 },
					new Tire() { Id = 18, VehicleId = 6, TireStatusId = 2 }
				);
		}
	}
}