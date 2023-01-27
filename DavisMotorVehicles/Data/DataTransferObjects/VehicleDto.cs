﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavisMotorVehicles.Data.DataTransferObjects
{
	public class VehicleDto
	{
		//public Vehicle Vehicle { get; set; }
		//public List<Tire>? Tires { get; set; }
		//public List<TireStatus>? TireStatuses { get; set; }
		//public VehicleType VehicleTypes { get; set; }
		public int VehicleId { get; set; }
		public string VinNumber { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }

		public int FuelLevel { get; set; }
		public List<TireVm>? Tires { get; set; }
		public int VehicleTypeId { get; set; }
		public string VehicleTypeName { get; set; }

	}
	public class TireVm
	{
		public int TireId { get; set; }
		public int TireStatusId { get; set; }
		public string TireStatus { get; set; }
	}
}
