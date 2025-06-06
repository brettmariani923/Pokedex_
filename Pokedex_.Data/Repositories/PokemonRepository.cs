using Dapper;
using System.Data;

namespace Pokedex.Data.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IDbConnection _connection;
        public PokemonRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<PokemonInfo> GetAllPokemonInfo()
        {
            return _connection.Query<PokemonInfo>("SELECT * FROM dbo.Pokemon");

        }

        public void AddPokemonInfo(int PokemonId, string Name, int HP, int Attack, int Defense, int Speed,
            string SpecialAttack, string SpecialDefense, string Ability, bool Legendary, string Region)
        { 
            _connection.Execute("INSERT INTO dbo.Pokemon (PokemonId, Name, HP, Attack, Defense, Speed, SpecialAttack, SpecialDefense, Ability, Legendary, Region) VALUES (@PokemonId, @Name, @HP, @Attack, @Defense, @Speed, @SpecialAttack, @SpecialDefense, @Ability, @Legendary, @Region)", 
                new { PokemonId = PokemonId, Name = Name, HP = HP, Attack = Attack, Defense = Defense, Speed = Speed, SpecialAttack = SpecialAttack, SpecialDefense = SpecialDefense, Ability = Ability, Legendary = Legendary, Region = Region }); 
        }
      
        public void UpdatePokemonInfo(int PokemonId, string Name, int HP, int Attack, int Defense, int Speed,
            string SpecialAttack, string SpecialDefense, string Ability, bool Legendary, string Region)
        {
            _connection.Execute("UPDATE dbo.Pokemon SET Name = @Name, HP = @HP, Attack = @Attack, Defense = @Defense, Speed = @Speed, SpecialAttack = @SpecialAttack, SpecialDefense = @SpecialDefense, Ability = @Ability, Legendary = @Legendary, Region = @Region WHERE PokemonId = @PokemonId", 
                new { PokemonId = PokemonId, Name = Name, HP = HP, Attack = Attack, Defense = Defense, Speed = Speed, SpecialAttack = SpecialAttack, specialDefense = SpecialDefense, Ability = Ability, Legendary = Legendary, Region = Region });
        }

        public IEnumerable<PokemonInfo> ReturnPokemonLike(string name, int limit = 25)
        {
            //Returns up to 25 Pokémon whose name contains the search term.
            return _connection.Query<PokemonInfo>(
                "SELECT TOP (@Limit) * FROM Pokemon WHERE Name LIKE @NamePattern",
                new { Limit = limit, NamePattern = $"%{name}%" }

            );
        }

        public void DeletePokemonInfo(int PokemonId)
        {
            _connection.Execute("DELETE FROM PokemonInfo WHERE PokemonId = @PokemonId", new { PokemonId });
        }
    }
}
