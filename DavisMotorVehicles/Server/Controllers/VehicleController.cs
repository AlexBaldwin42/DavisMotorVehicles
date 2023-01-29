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
		public IEnumerable<VehicleViewModel> Get()
		{
			using var db = new VehicleDatabaseContext();



			var vehicles = (from i in db.Vehicles
							select i)
					.Include(i => i.VehicleType)
					.Include(i => i.Tires)
					.ThenInclude(i => i.TireStatus).ToList();
			List<VehicleViewModel> vehicleDtos = new List<VehicleViewModel>();
			foreach (var vehicle in vehicles)
			{
				vehicleDtos.Add(ConvertToVehicleViewModel(vehicle));
			}
			return vehicleDtos;
		}

		[HttpPost]
		public VehicleViewModel Post(VehicleViewModel vehicleViewModel)
		{
			Vehicle vehicle = new()
			{
				Id = vehicleViewModel.VehicleId,
				FuelLevel = vehicleViewModel.FuelLevel,
				Make = vehicleViewModel.Make,
				Model = vehicleViewModel.Model,
				Year = vehicleViewModel.Year,
				VehicleTypeId = vehicleViewModel.VehicleTypeId,
				VinNumber = vehicleViewModel.Vin
			};

			if (vehicleViewModel.Tires != null)
			{
				vehicle.Tires = new();
				foreach (var tire in vehicleViewModel.Tires!)
				{
					vehicle.Tires.Add(new Tire() { Id = tire.TireId, TireStatusId = tire.TireStatusId, VehicleId = vehicle.Id });
				}

			}
			using var db = new VehicleDatabaseContext();
			vehicle = AddOrUpdate(vehicle);

			return GetVehicleViewModel(vehicle.Id);

		}


		public VehicleViewModel GetVehicleViewModel(int vehicleId)
		{
			using var db = new VehicleDatabaseContext();
			var vehicle = (from i in db.Vehicles
						   where i.Id == vehicleId
						   select i)
							.Include(i => i.VehicleType)
							.Include(i => i.Tires)
							.ThenInclude(i => i.TireStatus).Single();

			return ConvertToVehicleViewModel(vehicle);
		}
		public VehicleViewModel ConvertToVehicleViewModel(Vehicle vehicle)
		{
			VehicleViewModel vehicleDto = new VehicleViewModel();
			vehicleDto.VehicleId = vehicle.Id;
			vehicleDto.Vin = vehicle.VinNumber;
			vehicleDto.Make = vehicle.Make;
			vehicleDto.Model = vehicle.Model;
			vehicleDto.Year = vehicle.Year;
			vehicleDto.FuelLevel = vehicle.FuelLevel;
			vehicleDto.VehicleTypeName = vehicle.VehicleType.Name;
			vehicleDto.VehicleTypeId = vehicle.VehicleType.Id;
			vehicleDto.Tires = vehicle.Tires.Select(i => new TireVm()
			{
				TireId = i.Id,
				TireStatusId = i.TireStatus.Id,
				TireStatus = i.TireStatus.Status
			}).ToList();
			return vehicleDto;
		}

		public Vehicle AddOrUpdate(Vehicle vehicle)
		{
			using var db = new VehicleDatabaseContext();
			if (db.Vehicles.Where(i => i.Id == vehicle.Id).Count() > 0)
			{
				db.Update(vehicle);
			}
			else
			{
				vehicle.Id = default(int);
				db.Add(vehicle);
				db.SaveChanges();
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
			return vehicle;
		}

	}
}
