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
		public virtual Vehicle Vehicle { get; set; }
		public bool IsActive { get; set; } = true;
		public int TireStatusId { get; set; }
		public virtual TireStatus TireStatus { get; set; }
		
	}
}
