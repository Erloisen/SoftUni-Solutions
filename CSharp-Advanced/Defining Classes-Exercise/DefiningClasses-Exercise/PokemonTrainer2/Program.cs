using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer2
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] inputInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = inputInfo[0];
                string pokemonName = inputInfo[1];
                string pokemonElement = inputInfo[2];
                int pokemonHealth = int.Parse(inputInfo[3]);

                Trainer currentTrainer = new Trainer(trainerName);
                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.Exists(t => t.Name == trainerName))
                {
                    trainers.Add(currentTrainer);
                }

                trainers.First(t => t.Name == trainerName).Pokemons.Add(currentPokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == input))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.Health -= 10);
                        trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }

            Console.WriteLine(string.Join("\r\n", trainers.OrderByDescending(t => t.Badges)));
        }
    }
}
