using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const string ProfessionalRacerRacingBehavior = "strict";
        private const int ProfessionalRacerDrivingExperience = 30;

        public ProfessionalRacer(string username, ICar car)
            : base(username, ProfessionalRacerRacingBehavior, ProfessionalRacerDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 10;
        }
    }
}
