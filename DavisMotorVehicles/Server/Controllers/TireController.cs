//using DavisMotorVehicles.Data;
//using DavisMotorVehicles.Shared;
//using DavisMotorVehicles.Server.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using DavisMotorVehicles.Shared.ViewModels;
//using DavisMotorVehicles.Server.Repository;

//namespace DavisMotorVehicles.Server.Controllers
//{
//	[ApiController]
//	[Route("[controller]")]
//	public class TireController : ControllerBase
//	{
//		ITireRepository _tireRepository;
//		public TireController(ITireRepository tireRepository)
//		{
//			_tireRepository = tireRepository;
//		}

//		[HttpDelete("{id}")]
//		//[Route("/Tire/{id}")]
//		public IActionResult DeleteTire(int id)
//		{
//			var tireToDelete = _tireRepository.GetTire(id);
//			if (tireToDelete == null)
//			{
//				return BadRequest();
//			}
//			_tireRepository.DeleteTire(tireToDelete);
//			return NoContent();
//		}
//		[HttpGet]
//		public IActionResult GetTires()
//		{
//			return Ok(_tireRepository.GetTires());
//		}

//		//[HttpGet]
//		////[Route("/VehicleTypes")]
//		//public IActionResult GetNumberOfTires()
//		//{
//		//	var vehicleTypes = _tireRepository.GetNumberOfTires();
//		//	List<VehicleTypeViewModel> vehicleTypeViewModels = new();


//		//	foreach (var vehicleType in vehicleTypes)
//		//	{
//		//		vehicleTypeViewModels.Add(new VehicleTypeViewModel()
//		//		{
//		//			NumberOfTires = vehicleType.NumberOfTires,
//		//			VehicleTypeId = vehicleType.Id,
//		//			VehicleTypeName = vehicleType.Name
//		//		});
//		//	}

//		//	return Ok(vehicleTypeViewModels);

//		//}


//	}
//}
