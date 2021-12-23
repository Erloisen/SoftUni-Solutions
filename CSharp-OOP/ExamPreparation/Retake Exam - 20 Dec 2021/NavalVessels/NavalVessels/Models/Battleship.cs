using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double InitialArmorThickness = 300;
        private bool sonarMode;

        public Battleship(string name, double mainWeaponCaliber, double speed)
: base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            this.SonarMode = false;
        }

        public bool SonarMode 
        { 
            get => this.sonarMode; 
            private set => this.sonarMode = value;
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < 300)
            {
                this.ArmorThickness = InitialArmorThickness;
            }
        }

        public void ToggleSonarMode()
        {
            if (this.SonarMode)
            {
                this.SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
            else
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            string turnedOnOff = this.SonarMode == false ? "OFF" : "ON";
            sb.AppendLine($" *Sonar mode: {turnedOnOff}");

            return sb.ToString().TrimEnd();
        }
    }
}
