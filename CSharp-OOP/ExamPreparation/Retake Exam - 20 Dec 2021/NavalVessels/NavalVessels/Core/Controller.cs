using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var currentCaptain = this.captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            if (currentCaptain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            var currentVessel = this.vessels.Models.FirstOrDefault(v => v.Name == selectedVesselName);
            if (currentVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if (currentVessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            currentCaptain.AddVessel(currentVessel);
            currentVessel.Captain = currentCaptain;
            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackingVessel = this.vessels.FindByName(attackingVesselName);
            if (attackingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }

            if (attackingVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }

            var defendingVessel = this.vessels.FindByName(defendingVesselName);
            if (defendingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (defendingVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attackingVessel.Attack(defendingVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            var currentCaptain = this.captains.FirstOrDefault(c => c.FullName == captainFullName);
            return currentCaptain.Report();
        }

        public string HireCaptain(string fullName)
        {
            if (this.captains.Any(c => c.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            ICaptain currentCaptain = new Captain(fullName);
            this.captains.Add(currentCaptain);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel currentVessel;
            if (vesselType == nameof(Battleship))
            {
                currentVessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == nameof(Submarine))
            {
                currentVessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }

            if (this.vessels.Models.Any(v => v.Name == currentVessel.Name))
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            this.vessels.Add(currentVessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            var currentVessel = this.vessels.FindByName(vesselName);
            if (currentVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            currentVessel.RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = this.vessels.FindByName(vesselName);
            if (vessel != null)
            {
                if (vessel.GetType().Name == nameof(Battleship))
                {
                    Battleship battleship = (Battleship)vessel;
                    battleship.ToggleSonarMode();

                    return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
                }
                else if (vessel.GetType().Name == nameof(Submarine))
                {
                    Submarine submarine = (Submarine)vessel;
                    submarine.ToggleSubmergeMode();

                    return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
                }
            }
            
            return string.Format(OutputMessages.VesselNotFound, vesselName);
        }

        public string VesselReport(string vesselName)
        {
            var currentVessel = this.vessels.Models.FirstOrDefault(v => v.Name == vesselName);
            return currentVessel.ToString();
        }
    }
}
