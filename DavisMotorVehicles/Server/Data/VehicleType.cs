namespace DavisMotorVehicles.Server.Data
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
	}
}