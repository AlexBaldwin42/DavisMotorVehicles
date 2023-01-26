namespace DavisMotorVehicles.Server.Data
{
    public class Vehicle
    {
        public int Id { get; set; }

        //public int TypeId { get; set; }
        public string VinNumber { get; set; }

        public int FuelLevel { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
		public IEnumerable<Tire>? Tires { get; set; } = null!;
    }
}