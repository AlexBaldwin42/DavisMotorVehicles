using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavisMotorVehicles.Data
{
	public class Tire
	{
		public int Id { get; set; }
		public int VehicleId { get; set; }
		public Vehicle Vehicle { get; set; }
		public int TireId { get; set; }
		public TireStatus TireStatus { get; set; }
	}
}
