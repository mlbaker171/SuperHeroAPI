namespace SuperHeroAPI.Services.SuperHeroService
{
    
    public class SuperHeroService : ISuperHeroService
    {
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

        public List<SuperHero> AddHero(SuperHero hero)
        {
            superheroList.Add(hero);
            return superheroList;
        }

        public List<SuperHero>? DeleteHero(int id)
        {
            var hero = superheroList.Find(x => x.Id == id);
            if (hero == null) { return null; }

            superheroList.Remove(hero);

            return superheroList;
        }

        public List<SuperHero>? GetAllHeros()
        {
            return superheroList;
        }

        public SuperHero? GetSingleHero(int id)
        {
            var hero = superheroList.Find(x => x.Id == id);
            if (hero == null) { return null; }
            return hero;
        }

        public List<SuperHero>? UpdateHero(int id, SuperHero request)
        {
            var hero = superheroList.Find(x => x.Id == id);
            if (hero == null) { return null; }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            hero.Name = request.Name;

            return superheroList;
        }

    }//CLASS
}//NAMESPACE
