using DavisMotorVehicles.Data;

namespace DavisMotorVehicles.Server.Data
{
	public class TireStatus
	{
		public int Id { get; set; }
		public string Status { get; set; }
		public IEnumerable<Tire> Tires { get; set; } = null!;
	}
}