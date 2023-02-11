using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroControllerFAT : ControllerBase
    {

        /// <summary>
        /// THIS IS A FAT CONTROLLER - MEANING ALL THE LOGIC IS IN THE CONTROLLER.
        /// ARCHITECTURALLY THERE IS A BETTER APPROACH - USING THE REPOSITORY PATTERN AND DIRECT INJECTION OF SERVICES
        /// </summary>


        private static List<SuperHero> superheroList = new List<SuperHero> {

                new SuperHero
                {
                    Id = 1,
                    Name = "Spider Man",
                    FirstName= "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                },

                new SuperHero
                {
                    Id = 2,
                    Name = "Batman",
                    FirstName= "Bruce",
                    LastName = "Wayne",
                    Place = "Gotham"
                },

                 new SuperHero
                {
                    Id = 3,
                    Name = "Iron man",
                    FirstName= "Tony",
                    LastName = "Stark",
                    Place = "Malibu"
                }
            };


        //Need this attribute for Swagger. It would still func without it, but needed from Swagger
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHerosFAT()
        {
            return Ok(superheroList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHeroFAT(int id)
        {
            var hero = superheroList.Find(x => x.Id == id); 
            if(hero == null) { return NotFound("Sorry this Hero does not exist"); }
            return Ok(hero);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHeroFAT(SuperHero hero)
        {
            superheroList.Add(hero);
            return Ok(superheroList);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHeroFAT(int id, SuperHero request)
        {
            var hero = superheroList.Find(x => x.Id == id);
            if (hero == null) { return NotFound("Sorry this Hero does not exist"); }

            hero.FirstName = request.FirstName; 
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            hero.Name = request.Name;

            return Ok(superheroList);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHeroFAT(int id)
        {
            var hero = superheroList.Find(x => x.Id == id);
            if (hero == null) { return NotFound("Sorry this Hero does not exist"); }

            superheroList.Remove(hero);

            return Ok(superheroList);
        }

    }//CLASS
}//NAMESPACE
