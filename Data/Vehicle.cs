namespace DavisMotorVehicles.Data
{
	public class Vehicle
	{
		public int Id { get; set; }

		//public int TypeId { get; set; }
		public string VinNumber { get; set; }

		public int FuelLevel { get; set; }
		public VehicleType VehicleType { get; set; }
		public List<Tire> Tires { get; set; }
	}
}