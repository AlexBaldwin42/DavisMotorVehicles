using Microsoft.AspNetCore.Mvc;
using DavisMotorVehicles.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DavisMotorVehicles.Shared.ViewModels;
using DavisMotorVehicles.Server.Interfaces;
using DavisMotorVehicles.Server.Repository;

namespace DavisMotorVehicles.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class VehicleController : ControllerBase
	{
		private IVehicleRepository _vehicleRepository;
		//private ITireRepository _tireRepository;
		public VehicleController(IVehicleRepository vehicleRepository)//, ITireRepository tireRepository)
		{
			_vehicleRepository = vehicleRepository;
			//_tireRepository = tireRepository;
		}
		[HttpGet]
		//public IEnumerable<VehicleViewModel> Get()
		[ProducesResponseType(200, Type = typeof(IEnumerable<Vehicle>))]
		public IActionResult GetVehicles()
		{
			var vehicles = _vehicleRepository.GetVehicles();
			List<VehicleViewModel> vehicleDtos = new List<VehicleViewModel>();
			foreach (var vehicle in vehicles)
			{
				vehicleDtos.Add(ConvertToVehicleViewModel(vehicle));
			}
			return Ok(vehicleDtos);
		}

		[HttpPost]
		public VehicleViewModel Post(VehicleViewModel vehicleViewModel)
		{

			bool isNewVehicle = vehicleViewModel.VehicleId == default(int);
			Vehicle updatingVehicle;
			if (isNewVehicle)
			{
				updatingVehicle = new();
				updatingVehicle.Tires = new();
			}
			else
			{
				updatingVehicle = _vehicleRepository.GetVehicle(vehicleViewModel.VehicleId);
			}

			updatingVehicle.FuelLevel = vehicleViewModel.FuelLevel;
			updatingVehicle.Make = vehicleViewModel.Make;
			updatingVehicle.Model = vehicleViewModel.Model;
			updatingVehicle.Year = vehicleViewModel.Year;
			updatingVehicle.VehicleTypeId = vehicleViewModel.VehicleTypeId;
			updatingVehicle.VinNumber = vehicleViewModel.Vin;
			//updatingVehicle.VehicleType = null;


			//if(vehicleViewModel.Tir!es Count)
			// Assume all tires not being updated have been deleted.
			updatingVehicle.Tires.ForEach(i => i.IsActive = false);

			if (vehicleViewModel.Tires != null)
			{
				List<Tire> tiresToAdd = new();
				foreach (var tire in vehicleViewModel.Tires)
				{
					var tireToUpdate = updatingVehicle.Tires.Where(i => i.Id == tire.TireId).SingleOrDefault();
					if (tireToUpdate != null)
					{
						// Existing tire update
						tireToUpdate.TireStatusId = tire.TireStatusId;
						tireToUpdate.IsActive = true;
					}
					else
					{
						// New tire to add
						tiresToAdd.Add(new Tire() { TireStatusId = tire.TireStatusId, VehicleId = updatingVehicle.Id });
						//updatingVehicle.Tires.Add(new Tire() { TireStatusId = tire.TireStatusId, VehicleId = updatingVehicle.Id });
					}

				}
				updatingVehicle.Tires.AddRange(tiresToAdd);
			}
			_vehicleRepository.UpdateVehicle(updatingVehicle);
			//_dbContext.UpdateRange(vehicle);
			////if (vehicle.Tires != null)
			////{
			////	db.UpdateRange(vehicle.Tires);
			////}
			////vehicle = AddOrUpdate(vehicle);
			//_dbContext.SaveChanges();

			//var returnable = GetVehicleViewModel(updatingVehicle.Id);
			return GetVehicleViewModel(updatingVehicle.Id);
			//return returnable;
			//return ConvertToVehicleViewModel(updatingVehicle);

		}
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			if (!_vehicleRepository.VehicleExists(id))
			{
				return NotFound();
			}

			var vehicleToDelete = _vehicleRepository.GetVehicle(id);

			_vehicleRepository.DeleteVehicle(vehicleToDelete);
			return NoContent();

		}
		[HttpGet]
		[Route("/VehicleTypes")]
		public IActionResult GetNumberOfTires()
		{
			var vehicleTypes = _vehicleRepository.GetVehicleTypes();
			List<VehicleTypeViewModel> vehicleTypeViewModels = new();


			foreach (var vehicleType in vehicleTypes)
			{
				vehicleTypeViewModels.Add(new VehicleTypeViewModel()
				{
					NumberOfTires = vehicleType.NumberOfTires,
					VehicleTypeId = vehicleType.Id,
					VehicleTypeName = vehicleType.Name
				});
			}

			return Ok(vehicleTypeViewModels);

		}



		public VehicleViewModel GetVehicleViewModel(int vehicleId)
		{
			var vehicle = _vehicleRepository.GetVehicle(vehicleId);
			vehicle.Tires.RemoveAll(i => !i.IsActive);
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

		//public Vehicle AddOrUpdate(Vehicle vehicle)
		//{
		//	using var transation = _dbContext.Database.BeginTransaction();
		//	try
		//	{

		//		transation.CreateSavepoint("BeforeAddingVehicle");
		//		if (_dbContext.Vehicles.Where(i => i.Id == vehicle.Id).Count() > 0)
		//		{
		//			_dbContext.Update(vehicle);
		//		}
		//		else
		//		{
		//			vehicle.Id = default(int);
		//			_dbContext.Add(vehicle);
		//			_dbContext.SaveChanges();
		//		}
		//		if (vehicle.Tires != null)
		//		{

		//			foreach (var tire in vehicle.Tires)
		//			{
		//				if (_dbContext.Tires.Where(i => i.Id == tire.Id).Count() > 0)
		//				{
		//					_dbContext.Update(tire);
		//				}
		//				else
		//				{
		//					_dbContext.Add(tire);
		//				}

		//			}
		//		}
		//		_dbContext.SaveChanges();
		//		transation.Commit();
		//		return vehicle;
		//	}
		//	catch (Exception ex)
		//	{
		//		transation.RollbackToSavepoint("BeforeAddingVehicle");
		//		return new Vehicle();

		//	}

		//}

	}
}
