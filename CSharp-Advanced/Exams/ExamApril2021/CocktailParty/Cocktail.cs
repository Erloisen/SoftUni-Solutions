using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;

            Ingredients = new List<Ingredient>();
        }

        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel { get { return Ingredients.Sum(i => i.Alcohol); } }

        public void Add(Ingredient ingredient)
        {
            var currentIngredient = Ingredients.FirstOrDefault(i => i.Name == ingredient.Name);
            if (!Ingredients.Any(i => i.Name == ingredient.Name) && Capacity > Ingredients.Count)
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            var nameToRemove = Ingredients.FirstOrDefault(i => i.Name == name);
            if (nameToRemove != null)
            {
                Ingredients.Remove(nameToRemove);
                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.FirstOrDefault(i => i.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(i => i.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var item in Ingredients)
            {
                sb.AppendLine($"{item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
