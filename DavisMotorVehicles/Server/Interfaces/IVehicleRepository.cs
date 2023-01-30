using DavisMotorVehicles.Data;

namespace DavisMotorVehicles.Server.Interfaces
{
	public interface IVehicleRepository
	{
		ICollection<Vehicle> GetVehicles();
		bool UpdateVehicle(Vehicle vehicle);
		public bool VehicleExists(int vehicleId);
		public Vehicle GetVehicle(int vehicleId);
		public bool DeleteVehicle(Vehicle vehicle);
		//public bool DeleteTires(List<Tire> tiresToDelete);
		public ICollection<VehicleType> GetVehicleTypes();
		bool Save();
	}
}
