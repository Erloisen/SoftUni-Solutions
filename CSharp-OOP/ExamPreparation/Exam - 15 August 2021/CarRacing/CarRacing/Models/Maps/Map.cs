using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {

            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }
            else if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            racerOne.Race();
            double racerOneChanceOfWinnig = CalculatingRacerChanceOfWinning(racerOne);

            racerTwo.Race();
            double racerTwoChanceOfWinning = CalculatingRacerChanceOfWinning(racerTwo);

            if (racerOneChanceOfWinnig > racerTwoChanceOfWinning)
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }
        }

        private static double CalculatingRacerChanceOfWinning(IRacer racer)
        {
            double racerOneChanceOfWinnig = 0.0;
            if (racer.RacingBehavior == "strict")
            {
                racerOneChanceOfWinnig = racer.Car.HorsePower * racer.DrivingExperience * 1.2;
            }
            else if (racer.RacingBehavior == "aggressive")
            {
                racerOneChanceOfWinnig = racer.Car.HorsePower * racer.DrivingExperience * 1.1;
            }

            return racerOneChanceOfWinnig;
        }
    }
}
