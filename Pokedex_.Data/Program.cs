using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Pokedex.Data
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory
                .GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            IDbConnection connection = new SqlConnection(connectionString);

            connection.Open();

            var pokemonRepository = new Repositories.PokemonRepository(connection);


            //Returns all pokemon in the database
            /* var pokemon = pokemonRepository.GetAllPokemonInfo();

             foreach (var p in pokemon)
             {
                 Console.WriteLine($"PokemonId: {p.PokemonID} | Name: {p.Name} | HP: {p.HP} | Attack: {p.Attack} | Defense: {p.Defense} |" +
                     $" SpecialAttack: {p.SpecialAttack} | SpecialDefense: {p.SpecialDefense} | Speed: {p.Speed} | Ability: {p.Ability} | Legendary: {p.Legendary} | Region: {p.Region}");
                 Console.WriteLine();
             }
             */

            //Returns a specific pokemon by name, or a list of pokemon for a partial name match

            Console.WriteLine("Enter a Pokémon name to search for:");
            string searchTerm = Console.ReadLine() ?? string.Empty;

            var multiplePokemon = pokemonRepository.ReturnPokemonLike(searchTerm);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nMatching Pokémon:");
            Console.ResetColor();
            foreach (var p in multiplePokemon)
            {
                Console.Write($"PokemonId: {p.PokemonID} | Name: ");

                // Set name color to red
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(p.Name);
                Console.ResetColor();

                Console.WriteLine($" | HP: {p.HP} | Attack: {p.Attack} | Defense: {p.Defense} |" +
                                  $" SpecialAttack: {p.SpecialAttack} | SpecialDefense: {p.SpecialDefense} |" +
                                  $" Speed: {p.Speed} | Ability: {p.Ability} | Legendary: {p.Legendary} | Region: {p.Region}");
                Console.WriteLine();
            }

        }
    }
}
