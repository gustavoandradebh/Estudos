using Microsoft.AspNetCore.Mvc;
using MinhaFloresta.Domain.Entity;
using MinhaFloresta.Service.Class;
using System.Collections.Generic;

namespace MinhaFloresta.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlantsController : ControllerBase
    {
        private readonly PlantService _plantService;

        public PlantsController(PlantService plantService)
        {
            _plantService = plantService;
        }

        [HttpGet]
        public ActionResult<List<Plant>> Get() => _plantService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPlant")]
        public ActionResult<Plant> Get(string id)
        {
            var plant = _plantService.Get(id);

            if (plant == null)
                return NotFound();

            return plant;
        }

        [HttpPost]
        public ActionResult<Plant> Create(Plant plant)
        {
            _plantService.Create(plant);

            return CreatedAtRoute("GetPlant", new { id = plant.Id.ToString() }, plant);
        }

        [HttpPatch("{id:length(24)}")]
        public ActionResult Update(string id, Plant plantIn)
        {
            var plant = _plantService.Get(id);

            if (plant == null)
                return NotFound();

            _plantService.Update(id, plantIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            var plant = _plantService.Get(id);

            if (plant == null)
                return NotFound();

            _plantService.Remove(plant.Id);

            return NoContent();
        }
    }
}
