using DavisMotorVehicles.Data;
using DavisMotorVehicles.Server.Controllers;
using DavisMotorVehicles.Server.Interfaces;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavisMotorVehicles.Tests.Controller
{
	public class TireControllerTests
	{
		private readonly ITireRepository _tireRepository;
		public TireControllerTests()
		{
			_tireRepository = A.Fake<ITireRepository>();
		}
		[Fact]
		public void VehicleController_DeleteTire_ReturnOk()
		{
			// Arrange 
			var tire = A.Fake<Tire>();
			int tireId = 1;
			A.CallTo(() => _tireRepository.GetTire(tireId)).Returns(tire);
			A.CallTo(() => _tireRepository.DeleteTire(tire)).Returns(true);
			var controller = new TireController(_tireRepository);

			// Act 			
			var result = controller.DeleteTire(tireId);

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(NoContentResult));
		}
		[Fact]
		public void VehicleController_GetTires_ReturnOk()
		{
			// Arrange 
			var tires = A.Fake<ICollection<Tire>>();
			A.CallTo(() => _tireRepository.GetTires()).Returns(tires);
			var controller = new TireController(_tireRepository);

			// Act 			
			var result = controller.GetTires();

			// Assert	
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}
	}
}
