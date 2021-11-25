using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Make", "Model", 10, 100);
        }

        [Test]
        [TestCase("", "Yaris", 3.6, 60)]
        [TestCase(null, "Yaris", 3.6, 60)]
        [TestCase("Toyota", "", 3.6, 60)]
        [TestCase("Toyota", null, 3.6, 60)]
        [TestCase("Toyota", "Yaris", 0, 60)]
        [TestCase("Toyota", "Yaris", -1, 60)]
        [TestCase("Toyota", "Yaris", 3.6, 0)]
        [TestCase("Toyota", "Yaris", 3.6, -1)]
        [TestCase("Toyota", "Yaris", 3.6, -10)]
        public void CtorCarShpuldThrowExceptionIfValueIsNullOrEmptuy(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void CtorCarShouldSetInitalValuesWhenArgumentsAreValide()
        {
            string make = "Toyota";
            string model = "Yaris";
            double fuelConsumption = 3.6;
            double fuelCapacity = 60;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void RefuelMethodShouldThrowExceptionWhenFuelIsZeroOrNegative(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [Test]
        [TestCase(1)]
        [TestCase(25)]
        public void RefuelMethodShouldIncreaseFuelAmount(double fuelToRefuel)
        {
            car.Refuel(fuelToRefuel);
            Assert.That(car.FuelAmount, Is.EqualTo(fuelToRefuel));
        }

        [Test]
        public void RefuelMethodShouldSetFuelAmountToCapacityWhenAmountIsBiggerThenCapacity()
        {
            this.car.Refuel(car.FuelCapacity * 2);
            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        [TestCase(80, 125)]
        public void DriveMethodShouldDecreasesFuelAmoundByTheDistance(double fuelToRefuel, double distance)
        {
            this.car.Refuel(fuelToRefuel);
            this.car.Drive(distance);
            double fuelNeeded = (distance / 100) * car.FuelConsumption;
            Assert.That(car.FuelAmount, Is.EqualTo(fuelToRefuel - fuelNeeded));
        }

        [Test]
        [TestCase(1)]
        [TestCase(10)]
        public void DriveMethodShouldThrowExceptionWhenCarTankIsEmpty(double distance)
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }

        [Test]
        public void DriveMethodShouldDecreasesFuelAmoundToZeroWhenRequiredFuelIsEqualFuelAmount()
        {
            this.car.Refuel(car.FuelCapacity);
            double distance = this.car.FuelCapacity * this.car.FuelConsumption;
            this.car.Drive(distance);
            Assert.That(this.car.FuelAmount, Is.EqualTo(0));
        }
    }
}