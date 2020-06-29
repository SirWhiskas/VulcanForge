using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VulcanForge.Data;
using VulcanForge.Models;
using VulcanForge.Data;

namespace VulcanForge.Controllers
{
    [Route("api/worlds")]
    [ApiController]
    public class WorldsController : ControllerBase
    {
        private readonly IVulcanForgeRepo _repository;

        public WorldsController(IVulcanForgeRepo repository)
        {
            _repository = repository;
        }
        // GET api/worlds
        [HttpGet]
        public ActionResult <IEnumerable<World>> GetAllWords()
        {
            var worlds = _repository.GetWorlds();

            return Ok(worlds);
        }

        // GET api/worlds/{id}
        [HttpGet("{id}")]
        public ActionResult <World> GetWorldById(long id)
        {
            var world = _repository.GetWorldById(id);

            return Ok(world);
        }
    }
}
