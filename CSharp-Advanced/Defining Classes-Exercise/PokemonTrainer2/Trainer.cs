using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer2
{
    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;

            this.Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }
        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Count}";
        }
    }
}
