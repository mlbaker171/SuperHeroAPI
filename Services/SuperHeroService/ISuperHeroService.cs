namespace SuperHeroAPI.Services.SuperHeroService
{
    //INTERFACE TO DEFINE ALL OUR METHODS USED
    public interface ISuperHeroService
    {
        List<SuperHero>? GetAllHeros();

        SuperHero? GetSingleHero(int id);

        List<SuperHero> AddHero(SuperHero hero);

        List<SuperHero>? UpdateHero(int id, SuperHero hero);

        List<SuperHero>? DeleteHero(int id);
    }
}
