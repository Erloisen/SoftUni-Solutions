using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;
        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium currentAquarium;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                currentAquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                currentAquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            aquariums.Add(currentAquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration currentDecodarion;

            if (decorationType == nameof(Ornament))
            {
                currentDecodarion = new Ornament();
            }
            else if (decorationType == nameof(Plant))
            {
                currentDecodarion = new Plant();
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            decorations.Add(currentDecodarion);
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish currentFish;
            if (fishType == nameof(FreshwaterFish))
            {
                currentFish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                currentFish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            IAquarium currentAquarium = aquariums.Find(a => a.Name == aquariumName);
            if (fishType == nameof(FreshwaterFish) && currentAquarium.GetType().Name == nameof(FreshwaterAquarium))
            {
                currentAquarium.AddFish(currentFish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else if (fishType == nameof(SaltwaterFish) && currentAquarium.GetType().Name == nameof(SaltwaterAquarium))
            {
                currentAquarium.AddFish(currentFish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }

            return "Water not suitable.";
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium currentAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            decimal sumOfAquariumValue = 0.0m;

            foreach (var fish in currentAquarium.Fish)
            {
                sumOfAquariumValue += fish.Price;
            }

            foreach (var decoration in currentAquarium.Decorations)
            {
                sumOfAquariumValue += decoration.Price;
            }

            return $"The value of Aquarium {aquariumName} is {sumOfAquariumValue:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium currentAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            currentAquarium.Feed();
            return $"Fish fed: {currentAquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            this.aquariums.FirstOrDefault(a => a.Name == aquariumName).AddDecoration(decoration);
            decorations.Remove(decoration);
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
