using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavisMotorVehicles.Data.DataTransferObjects
{
	public class VehicleDto
	{
		public Vehicle Vehicle { get; set; }
		public List<Tire>? Tires { get; set; }
		public List<TireStatus>? TireStatuses {get;set;}
		public VehicleType VehicleTypes { get; set; }

	}
}
