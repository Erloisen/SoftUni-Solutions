using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, Trainer>();
            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] information = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = information[0];
                string pokemonName = information[1];
                string pokemonElement = information[2];
                int pokemonHealth = int.Parse(information[3]);

                if (!dictionary.ContainsKey(trainerName))
                {
                    Trainer newTrainer = new Trainer(trainerName);
                    dictionary.Add(trainerName, newTrainer);
                }

                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                Trainer trainer = dictionary[trainerName];
                trainer.Pokemons.Add(currentPokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in dictionary)
                {
                    if (trainer.Value.Pokemons.Any(p => p.Element == input))
                    {
                        trainer.Value.Badges += 1;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Value.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }

            foreach (var item in dictionary.OrderByDescending(t => t.Value.Badges))
            {
                Console.WriteLine($"{item.Key} {item.Value.Badges} {item.Value.Pokemons.Count}");
            }
        }
    }
}
