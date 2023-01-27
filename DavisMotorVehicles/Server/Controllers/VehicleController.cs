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
				vehicleDto.VehicleId = vehicle.Id;
				vehicleDto.VinNumber = vehicle.VinNumber;
				vehicleDto.Make = vehicle.Make;
				vehicleDto.Model = vehicle.Model;
				vehicleDto.Year = vehicle.Year;
				vehicleDto.FuelLevel = vehicle.FuelLevel;
				vehicleDto.VehicleTypeName = vehicle.VehicleType.Name;
				vehicleDto.VehicleTypeName = vehicle.VehicleType.Name;
				vehicleDto.Tires = vehicle.Tires.Select(i => new TireVm()
				{
					TireId = i.Id,
					TireStatusId = i.TireStatus.Id,
					TireStatus = i.TireStatus.Status
				}).ToList();
				vehicleDtos.Add(vehicleDto);
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
			if (db.Vehicles.Where(i => i.Id == vehicle.VehicleId).Count() > 0)
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
					if (db.Tires.Where(i => i.Id == tire.TireId).Count() > 0)
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
