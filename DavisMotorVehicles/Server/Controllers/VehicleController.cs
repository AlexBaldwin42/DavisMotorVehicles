using Microsoft.AspNetCore.Mvc;
using DavisMotorVehicles.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DavisMotorVehicles.Data.DataTransferObjects;

namespace DavisMotorVehicles.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class VehicleController : ControllerBase
	{

		[HttpGet]
		public IEnumerable<VehicleDto> Get()
		{
			using var db = new VehicleDatabaseContext();



			var vehicles = (from i in db.Vehicles
							select i)
					.Include(i => i.VehicleType)
					.Include(i => i.Tires)
					.ThenInclude(i => i.TireStatus).ToList();
			List<VehicleDto> vehicleDtos = new List<VehicleDto>();
			foreach (var vehicle in vehicles)
			{
				VehicleDto vehicleDto = new VehicleDto();
				vehicleDto.Vehicle = vehicle;
				vehicleDto.Tires = vehicle.Tires;
				vehicleDto.TireStatuses = vehicle.Tires.Select(i => i.TireStatus).ToList();
				vehicleDto.VehicleTypes = vehicle.VehicleType;
				vehicleDtos.Add(vehicleDto);
			}

			if (vehicles.Count == 0)
			{
				var vehicleType = db.VehicleTypes.First();

				Vehicle newVehicle1 = new Vehicle() { FuelLevel = 50, VinNumber = "djfwieurj8444", VehicleType = vehicleType };
				Vehicle newVehicle2 = new Vehicle() { FuelLevel = 70, VinNumber = "877kdjfiiwuwuee", VehicleType = vehicleType };

				db.Add(newVehicle1);
				db.Add(newVehicle2);
				db.SaveChanges();
				vehicles = db.Vehicles.Include(i => i.VehicleType).ToList();

			}
			return vehicleDtos;

		}

		[HttpPost]
		public void Post(VehicleDto vehicle)
		{
			using var db = new VehicleDatabaseContext();
			AddOrUpdate(vehicle);
			AddOrUpdate(vehicle);
			db.SaveChanges();
		}


		public void AddOrUpdate(VehicleDto vehicle)
		{
			using var db = new VehicleDatabaseContext();
			if (db.Vehicles.Where(i => i.Id == vehicle.Vehicle.Id).Count() > 0)
			{
				db.Update(vehicle);
			}
			else
			{
				db.Add(vehicle);
			}
			if (vehicle.Tires != null)
			{

				foreach (var tire in vehicle.Tires)
				{
					if (db.Tires.Where(i => i.Id == tire.Id).Count() > 0)
					{
						db.Update(tire);
					}
					else
					{
						db.Add(tire);
					}

				}
			}
			db.SaveChanges();
		}



	}
}
