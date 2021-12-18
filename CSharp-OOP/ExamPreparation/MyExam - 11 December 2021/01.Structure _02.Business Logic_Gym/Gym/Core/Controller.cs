using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;
        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;
            switch (athleteType)
            {
                case nameof(Boxer):
                    athlete = new Boxer(athleteName, motivation, numberOfMedals);
                    break;
                case nameof(Weightlifter):
                    athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            IGym currentGym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            if (currentGym.GetType().Name == nameof(BoxingGym) && athlete.GetType().Name == nameof(Boxer))
            {
                currentGym.AddAthlete(athlete);
            }
            else if (currentGym.GetType().Name == nameof(WeightliftingGym) && athlete.GetType().Name == nameof(Weightlifter))
            {
                currentGym.AddAthlete(athlete);
            }
            else
            {
                return string.Format(OutputMessages.InappropriateGym);
            }

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment currentEquipment;
            switch (equipmentType)
            {
                case nameof(BoxingGloves):
                    currentEquipment = new BoxingGloves();
                    break;
                case nameof(Kettlebell):
                    currentEquipment = new Kettlebell();
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            this.equipment.Add(currentEquipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            switch (gymType)
            {
                case nameof(BoxingGym):
                    gym = new BoxingGym(gymName);
                    break;
                case nameof(WeightliftingGym):
                    gym = new WeightliftingGym(gymName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            this.gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym currentGym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            var sum = currentGym.EquipmentWeight;

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, sum.ToString("F2"));
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment desiredEquipment = this.equipment.FindByType(equipmentType);
            if (desiredEquipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            this.equipment.Remove(desiredEquipment);

            IGym currentGym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            currentGym.AddEquipment(desiredEquipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym currentGym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            currentGym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, currentGym.Athletes.Count);
        }
    }
}
