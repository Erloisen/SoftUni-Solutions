using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            this.Nаmе = name;
            this.Badges = 0;

            Pokemons = new List<Pokemon>();
        }
        public string Nаmе { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}
