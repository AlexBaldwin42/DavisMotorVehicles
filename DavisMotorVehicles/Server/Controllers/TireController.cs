using DavisMotorVehicles.Data;
using Microsoft.AspNetCore.Mvc;

namespace DavisMotorVehicles.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TireController : ControllerBase
	{
		[HttpDelete]
		[Route("/Tire/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			using var db = new VehicleDatabaseContext();
			var tireToDelete = db.Tires.Where(i => i.Id == id).Single();
			tireToDelete.IsActive = false;
			db.Update(tireToDelete);
			await db.SaveChangesAsync();
			return NoContent();
		}
		[HttpGet]
		public IEnumerable<Tire> Get()
		{

			using var db = new VehicleDatabaseContext();
			return db.Tires.ToList();
		}
	}
}
