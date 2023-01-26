//namespace DavisMotorVehicles.Server.Data
//{
//    using Microsoft.EntityFrameworkCore;
//    using System.Data.Common;

//    public class VehicleDatabaseContext : DbContext
//    {
//        public DbSet<Vehicle> Vehicles { get; set; }
//        public DbSet<VehicleType> VehicleTypes { get; set; }
//        public DbSet<Tire> Tires { get; set; }
//        public DbSet<TireStatus> TireStatuses { get; set; }

//        public string DbPath { get; set; }

//        public VehicleDatabaseContext()
//        {
//            //var folder = Environment.SpecialFolder.LocalApplicationData;
//            var path = System.IO.Directory.GetCurrentDirectory();
//            //var path = Environment.GetFolderPath(folder);
//            DbPath = System.IO.Path.Join(path, "Vehicles.db");
//        }

//        // The following configures EF to create a Sqlite database file in the
//        // special "local" folder for your platform.
//        protected override void OnConfiguring(DbContextOptionsBuilder options)
//            => options.UseSqlite($"Data Source={DbPath}");

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Vehicle>()
//                .HasKey(e => e.Id);
//            modelBuilder.Entity<Vehicle>()
//                .HasIndex(i => i.VinNumber)
//                .IsUnique();

//			modelBuilder.Entity<Vehicle>()
//				.HasOne(i => i.VehicleType)
//				.WithMany(i => i.Vehicles)
//				.HasPrincipalKey(i => i.Id);
//			modelBuilder.Entity<VehicleType>()
//				.HasKey(e => e.Id);
//			modelBuilder.Entity<VehicleType>()
//				.HasMany(i => i.Vehicles)
//				.WithOne(i => i.VehicleType);
            
//			modelBuilder.Entity<Tire>()
//				.HasKey(e => e.Id);
//            modelBuilder.Entity<Tire>()
//                .HasOne(e => e.TireStatus)
//                .WithMany(e => e.Tires)
//                .HasForeignKey(e => e.StatusId);
//            modelBuilder.Entity<Tire>()
//                .HasOne(e=> e.Vehicle)
//				.WithMany(e => e.Tires)
//				.HasForeignKey(e => e.VehicleId);

//			modelBuilder.Entity<TireStatus>()
//				.HasKey(e => e.Id);
//			modelBuilder.Entity<TireStatus>()
//				.HasMany(e=> e.Tires)
//				.WithOne(e => e.TireStatus)
//				.HasForeignKey(e => e.StatusId);
//            modelBuilder.Entity<TireStatus>()
//                .HasData(
//                new TireStatus() { Status = "Bad" },
//                new TireStatus() { Status = "Ok" },
//                new TireStatus() { Status = "Good" },
//                new TireStatus() { Status = "Great" }
//            );
//		}
//    }
//}