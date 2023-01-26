using Microsoft.AspNetCore.Hosting.Server;

namespace DavisMotorVehicles.Server.Data
{
	public class Tire
	{
		public int Id { get; set; }
		public int StatusId { get; set; }
		public int VehicleId { get; set; }
		public Vehicle Vehicle { get; set; } 
		public TireStatus TireStatus { get; set; } = null!;

	}
}
