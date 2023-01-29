using Microsoft.AspNetCore.Mvc;
using DavisMotorVehicles.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DavisMotorVehicles.Shared.ViewModels;

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
							where i.IsActive
							select i)
					.Include(i => i.VehicleType)
					.Include(i => i.Tires.Where(t => t.IsActive))
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
			db.UpdateRange(vehicle);
			//if (vehicle.Tires != null)
			//{
			//	db.UpdateRange(vehicle.Tires);
			//}
			//vehicle = AddOrUpdate(vehicle);
			db.SaveChanges();

			return GetVehicleViewModel(vehicle.Id);

		}
		[HttpDelete]
		[Route("/Vehicle/{id}")]
		public void Delete(int id)
		{
			using var db = new VehicleDatabaseContext();
			var vehicleToDelete = db.Vehicles.Where(i => i.Id == id).Single();
			vehicleToDelete.IsActive = false;
			//db.Update(vehicleToDelete);
			db.SaveChanges();

		}




		public VehicleViewModel GetVehicleViewModel(int vehicleId)
		{
			using var db = new VehicleDatabaseContext();
			var vehicle = (from i in db.Vehicles
						   where i.Id == vehicleId
						   select i)
							.Include(i => i.VehicleType)
							.Include(i => i.Tires.Where(t => t.IsActive))
							.ThenInclude(i => i.TireStatus).Single();

			return ConvertToVehicleViewModel(vehicle);
		}
		public VehicleViewModel ConvertToVehicleViewModel(Vehicle vehicle)
		{
			VehicleViewModel vehicleViewModel = new VehicleViewModel();
			vehicleViewModel.VehicleId = vehicle.Id;
			vehicleViewModel.Vin = vehicle.VinNumber;
			vehicleViewModel.Make = vehicle.Make;
			vehicleViewModel.Model = vehicle.Model;
			vehicleViewModel.Year = vehicle.Year;
			vehicleViewModel.FuelLevel = vehicle.FuelLevel;
			vehicleViewModel.VehicleTypeName = vehicle.VehicleType.Name;
			vehicleViewModel.VehicleTypeId = vehicle.VehicleType.Id;
			vehicleViewModel.Tires = vehicle.Tires.Select(i => new TireVm()
			{
				TireId = i.Id,
				TireStatusId = i.TireStatus.Id,
				TireStatus = i.TireStatus.Status
			}).ToList();
			return vehicleViewModel;
		}

		public Vehicle AddOrUpdate(Vehicle vehicle)
		{
			using var db = new VehicleDatabaseContext();
			using var transation = db.Database.BeginTransaction();
			try
			{

				transation.CreateSavepoint("BeforeAddingVehicle");
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
				transation.Commit();
				return vehicle;
			}
			catch (Exception ex)
			{
				transation.RollbackToSavepoint("BeforeAddingVehicle");
				return new Vehicle();

			}

		}

	}
}
