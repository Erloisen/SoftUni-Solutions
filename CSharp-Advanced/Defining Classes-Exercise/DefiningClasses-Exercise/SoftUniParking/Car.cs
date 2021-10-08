using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    class Car
    {
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public override string ToString() =>
            $"Make: {Make}\r\n" +
            $"Model: {Model}\r\n" +
            $"HorsePower: {HorsePower}\r\n" +
            $"RegistrationNumber: {RegistrationNumber}";
    }
}
