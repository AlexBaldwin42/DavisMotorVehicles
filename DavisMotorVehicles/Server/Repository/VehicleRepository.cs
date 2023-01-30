using DavisMotorVehicles.Data;
using DavisMotorVehicles.Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DavisMotorVehicles.Server.Repository
{
	public class VehicleRepository : IVehicleRepository
	{
		VehicleDatabaseContext _dbContext;
		public VehicleRepository(VehicleDatabaseContext context)
		{
			_dbContext = context;
		}

		public ICollection<Vehicle> GetVehicles()
		{
			return _dbContext.Vehicles
				.Where(i => i.IsActive)
				.Include(i => i.VehicleType)
				.Include(i => i.Tires.Where(t => t.IsActive))
				.ThenInclude(i => i.TireStatus).ToList();
		}

		public Vehicle GetVehicle(int vehicleId)
		{
			return _dbContext.Vehicles
				.Where(i => i.Id == vehicleId)
				.Where(i => i.IsActive)
				.Include(i => i.VehicleType)
				.Include(i => i.Tires)
				.ThenInclude(i => i.TireStatus).Single();
		}

		public bool VehicleExists(int vehicleId)
		{
			return _dbContext.Vehicles.Where(i => i.Id == vehicleId).Any();
		}
		public bool UpdateVehicle(Vehicle vehicle)
		{

			_dbContext.UpdateRange(vehicle);
			return Save();
		}
		public bool DeleteVehicle(Vehicle vehicleToDelete)
		{
			vehicleToDelete.IsActive = false;
			_dbContext.Vehicles.Update(vehicleToDelete);
			return Save();
		}
		//public bool DeleteTires(List<Tire> tiresToDelete)
		//{
		//	tiresToDelete.ForEach(i => i.IsActive = false);
		//	_dbContext.Tires.UpdateRange(tiresToDelete);
		//	return Save();
		//}
		public ICollection<VehicleType> GetVehicleTypes()
		{
			return _dbContext.VehicleTypes.ToList();
		}

		public bool Save()
		{
			var saved = _dbContext.SaveChanges();
			return saved > 0 ? true : false;
		}
	}
}
