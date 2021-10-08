using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Pokemon
    {
        public Pokemon(string pokemonName, string element, int health)
        {
            this.PokemonName = pokemonName;
            this.Element = element;
            this.Health = health;
        }
        public string PokemonName { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}
