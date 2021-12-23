using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Contracts
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private double armorThickness;
        private ICaptain captain;
        private readonly List<string> targets;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.ArmorThickness = armorThickness;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.targets = new List<string>();

        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }

                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get => this.captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }

                this.captain = value;
            }
        }
        public double ArmorThickness 
        {
            get => this.armorThickness;
            set
            {
                if (value < 0)
                {
                    this.armorThickness = 0;
                }
                else
                {
                    this.armorThickness = value;
                }
            }
        }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets => this.targets.AsReadOnly();

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;
            this.targets.Add(target.Name);
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");

            if (targets.Count == 0)
            {
                sb.AppendLine(" *Targets: None");
            }
            else
            {
                sb.AppendLine($" *Targets: {string.Join(", ", this.targets)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
