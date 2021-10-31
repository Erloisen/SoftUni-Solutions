using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfNameIsNullOrEmpthy(value);

                this.name = value;
            }
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                Validator.ThrowIfStatIsOutOfRange(value, "Endurance");

                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;
            private set
            {
                Validator.ThrowIfStatIsOutOfRange(value, "Sprint");

                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            private set
            {
                Validator.ThrowIfStatIsOutOfRange(value, "Dribble");

                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            private set
            {
                Validator.ThrowIfStatIsOutOfRange(value, "Passing");

                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            private set
            {
                Validator.ThrowIfStatIsOutOfRange(value, "Shooting");

                this.shooting = value;
            }
        }

        public double AverageSkillPoint
        {
            get => Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0);
        }
    }
}
