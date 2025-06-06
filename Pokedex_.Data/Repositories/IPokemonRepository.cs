namespace Pokedex.Data.Repositories
{
    public interface IPokemonRepository
    {
        public IEnumerable<PokemonInfo> GetAllPokemonInfo();
        public void AddPokemonInfo(int PokemonId, string Name, int HP, int Attack, int Defense, int Speed,
            string SpecialAttack, string SpecialDefense, string Ability, bool Legendary, string Region);
        public void UpdatePokemonInfo(int PokemonId, string Name, int HP, int Attack, int Defense, int Speed,
            string SpecialAttack, string SpecialDefense, string Ability, bool Legendary, string Region);

        public void DeletePokemonInfo(int PokemonId);
    }
}
