namespace DavisMotorVehicles.Data
{
	public class Vehicle
	{
		public int Id { get; set; }

		//public int TypeId { get; set; }
		public string VinNumber { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public int FuelLevel { get; set; }
		public int VehicleTypeId { get; set; }
		public virtual VehicleType VehicleType { get; set; }
		public virtual List<Tire> Tires { get; set; }
	}
}