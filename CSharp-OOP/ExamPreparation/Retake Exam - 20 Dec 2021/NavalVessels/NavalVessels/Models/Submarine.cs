using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmorThickness = 200;
        private bool submergeMode;

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode 
        { 
            get => submergeMode; 
            private set => submergeMode = value; 
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < 200)
            {
                this.ArmorThickness = InitialArmorThickness;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode)
            {
                this.SubmergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
            else
            {
                this.SubmergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            string turnedOnOff = this.SubmergeMode == false ? "OFF" : "ON";
            sb.AppendLine($" *Submerge mode: {turnedOnOff}");

            return sb.ToString().TrimEnd();
        }
    }
}
