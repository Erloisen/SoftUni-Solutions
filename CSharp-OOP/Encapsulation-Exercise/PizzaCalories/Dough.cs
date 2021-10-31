using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;
        private const string InvaideDoughExceptionMessage = "Invalid type of dough.";

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        public string FlourType
        {
            get => this.flourType;
            private set
            {
                Validator.ThrowIfValueIsNotAllowed(new HashSet<string> { "white", "wholegrain" }, value.ToLower(), InvaideDoughExceptionMessage);
                
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                Validator.ThrowIfValueIsNotAllowed(new HashSet<string> { "crispy", "chewy", "homemade" }, value.ToLower(), InvaideDoughExceptionMessage);

                this.bakingTechnique = value;
            }
        }
        public int Weight
        {
            get => this.weight;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(MinWeight, MaxWeight, value, $"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");

                this.weight = value;
            }
        }

        public double CalculatingCalories()
        {
            var flourTypeModifier = GetFlourTypeModifier();
            var bakingTechniqueModifire = GetBakingTechniqueModifire();

            return this.Weight * 2 * flourTypeModifier * bakingTechniqueModifire;
        }
        private double GetFlourTypeModifier()
        {
            var flourTypeToLower = this.FlourType.ToLower();
            var modifier = 0.0;
            switch (flourTypeToLower)
            {
                case "white":
                    modifier = 1.5;
                    break;
                case "wholegrain":
                    modifier = 1.0;
                    break;
            }

            return modifier;
        }

        private double GetBakingTechniqueModifire()
        {
            var backingTechniqueLower = this.BakingTechnique.ToLower();
            var modifier = 0.0;
            switch (backingTechniqueLower)
            {
                case "crispy":
                    modifier = 0.9;
                    break;
                case "chewy":
                    modifier = 1.1;
                    break;
                case "homemade":
                    modifier = 1.0;
                    break;
            }

            return modifier;
        }
    }
}
