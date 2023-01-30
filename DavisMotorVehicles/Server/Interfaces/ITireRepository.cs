using DavisMotorVehicles.Data;

namespace DavisMotorVehicles.Server.Interfaces
{
	public interface ITireRepository
	{
		bool DeleteTire(Tire tire);
		ICollection<Tire> GetTires();
		Tire GetTire(int tireId);
		bool Save();
		ICollection<VehicleType> GetNumberOfTires();
		public bool DeleteTires(List<Tire> tiresToDelete);
	}
}
