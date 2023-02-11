using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    { /// <summary>
      /// THIS IS A CONTROLLER BASED ON THE REPOSITORY PATTERN AND DIRECT INJECTION OF SERVICES
      /// </summary>
      

        private readonly ISuperHeroService _superHeroService;                          



        //CONSTRUCTOR - THIS IS WHERE WE INJECT THE SUPERHEROSSERVICE
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }
      


        //Need this attribute for Swagger. It would still func without it, but needed from Swagger
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            var result = _superHeroService.GetAllHeros();
            if (result == null)
            {
                return NotFound("Hero not found");
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = _superHeroService.GetSingleHero(id);
            if (result == null)
            {
                return NotFound("Hero not found");
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var result = _superHeroService.AddHero(hero);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var result = _superHeroService.UpdateHero(id, request);
            if (result == null)
            {
                return NotFound("Hero not found");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = _superHeroService.DeleteHero(id);
            if(result == null)
            {
                return NotFound("Hero not found");
            }

            return Ok(result);
        }

    }//CLASS
}//NAMESPACE

