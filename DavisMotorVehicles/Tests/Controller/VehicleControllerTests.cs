using DavisMotorVehicles.Server.Interfaces;
using System;
using FakeItEasy;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavisMotorVehicles.Shared.ViewModels;
using DavisMotorVehicles.Server.Controllers;
using FluentAssertions;
using DavisMotorVehicles.Data;
using Microsoft.AspNetCore.Mvc;

namespace DavisMotorVehicles.Tests.Controller
{
	public class VehicleControllerTests
	{
		private readonly IVehicleRepository _vehicleRepository;
		public VehicleControllerTests()
		{
			_vehicleRepository = A.Fake<IVehicleRepository>();
		}

		[Fact]
		public void VehicleController_UpdateVehicle_ReturnOk()
		{
			//Arrange 
			var vehicles = A.Fake<ICollection<Vehicle>>();
			var vehicle = A.Fake<Vehicle>();
			var vehicleViewModel = A.Fake<VehicleViewModel>();

			A.CallTo(() => _vehicleRepository.GetVehicle(vehicleViewModel.VehicleId)).Returns(vehicle);
			A.CallTo(() => _vehicleRepository.UpdateVehicle(vehicle));
			var controller = new VehicleController(_vehicleRepository);

			//Act 			
			var result = controller.UpdateVehicle(vehicleViewModel);
			
			//Assert 			
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}
		[Fact]
		public void VehicleController_UpdateVehicle_ReturnBadRequest()
		{
			//Arrange 
			var vehicles = A.Fake<ICollection<Vehicle>>();
			var vehicle = A.Fake<Vehicle>();
			var vehicleViewModel = A.Fake<VehicleViewModel>();
			vehicleViewModel.Vin = "";

			var controller = new VehicleController(_vehicleRepository);

			//Act 			
			var result = controller.UpdateVehicle(vehicleViewModel);

			//Assert 			
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(BadRequestResult));
		}
		[Fact]
		public void VehicleController_GetVehicle_ReturnOk()
		{
			//Arrange 
			var vehicles = A.Fake<ICollection<Vehicle>>();
			A.CallTo(() => _vehicleRepository.GetVehicles()).Returns(vehicles);
			var controller = new VehicleController(_vehicleRepository);

			//Act 			
			var result = controller.GetVehicles();
			
			//Assert 			
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}

	}
}
