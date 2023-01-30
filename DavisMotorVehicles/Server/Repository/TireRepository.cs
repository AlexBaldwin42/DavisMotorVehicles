using DavisMotorVehicles.Data;
using DavisMotorVehicles.Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DavisMotorVehicles.Server.Repository
{
	public class TireRepository : ITireRepository
	{
		VehicleDatabaseContext _dbContext;
		public TireRepository(VehicleDatabaseContext context)
		{
			_dbContext = context;
		}

		public bool DeleteTire(Tire tire)
		{
			tire.IsActive = false;
			_dbContext.Tires.Update(tire);
			return Save();
		}

		public bool DeleteTires(List<Tire> tiresToDelete)
		{
			tiresToDelete.ForEach(i=> i.IsActive = false);
			_dbContext.Tires.UpdateRange(tiresToDelete);
			return Save();
		}
		public ICollection<Tire> GetTires()
		{
			return _dbContext.Tires
				.Where(i => i.IsActive)
				.Include(i => i.TireStatus)
				.ToList();
		}

		public Tire GetTire(int tireId)
		{
			return _dbContext.Tires
				.Where(i => i.Id == tireId)
				.Where(i => i.IsActive)
				.Include(i => i.TireStatus)
				.Single();
		}

		public bool Save()
		{
			var saved = _dbContext.SaveChanges();
			return saved > 0 ? true : false;
		}

		public ICollection<VehicleType> GetNumberOfTires()
		{
			return _dbContext.VehicleTypes.ToList();
		}
	}
}
