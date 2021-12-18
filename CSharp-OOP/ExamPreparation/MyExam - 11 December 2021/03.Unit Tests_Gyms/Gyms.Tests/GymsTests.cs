using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        [TestCase(null, 10)]
        [TestCase("", 10)]
        public void GymNameShouldThrowExceptionWhenTryToSetInvalideName(string name, int capacity)
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(name, capacity));
        }

        [Test]
        public void GymNameShouldSetName()
        {
            Gym gym = new Gym("Gym", 1);
            Assert.That("Gym", Is.EqualTo(gym.Name));
        }

        [Test]
        [TestCase("Gym", -1)]
        [TestCase("Gym", -10)]
        public void GymCapacityShouldThrowExceptionWhenTryToSetInvalideCapacity(string name, int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Gym(name, capacity));
        }

        [Test]
        [TestCase("Gym", 0)]
        [TestCase("Gym", 1)]
        [TestCase("Gym", 10)]
        public void GymCapacityShouldSetCapacity(string name, int capacity)
        {
            Gym gym = new Gym(name, capacity);
            Assert.That(capacity, Is.EqualTo(gym.Capacity));
        }

        [Test]
        public void GymCapacityShouldWorkProperly()
        {
            Athlete athlete1 = new Athlete("NameOne Surname");
            Athlete athlete2 = new Athlete("NameTwo Surname");
            Athlete athlete3 = new Athlete("NameThree Surname");
            Gym gym = new Gym("MyGym", 3);
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);
            Assert.That(3, Is.EqualTo(gym.Count));
        }

        [Test]
        public void GymCapacityShouldBeZero()
        {
            Gym gym = new Gym("MyGym", 3);
            Assert.That(0, Is.EqualTo(gym.Count));
        }

        [Test]
        public void GymAddMethodShouldThrowExceptionWhenCapacityIsOver()
        {
            Athlete athlete1 = new Athlete("NameOne Surname");
            Athlete athlete2 = new Athlete("NameTwo Surname");
            Athlete athlete3 = new Athlete("NameThree Surname");
            Gym gym = new Gym("MyGym", 2);
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete3));
        }

        [Test]
        public void GymAddMethodShouldWorkProperly()
        {
            Athlete athlete = new Athlete("Name Surname");
            Gym gym = new Gym("MyGym", 2);
            gym.AddAthlete(athlete);
            Assert.AreEqual(gym.Count, 1);
        }

        [Test]
        public void GymRemoveMethodShouldThrowExceptionWhenTryToRemoveNonExcistingAthlete()
        {
            Gym gym = new Gym("MyGym", 2);
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("NameTwo Surname"));
        }

        [Test]
        public void GymRemoveMethodShouldWorkProperly()
        {
            Gym gym = new Gym("MyGym", 2);
            Athlete athlete = new Athlete("Name Surname");
            gym.AddAthlete(athlete);
            gym.RemoveAthlete("Name Surname");
            Assert.AreEqual(gym.Count, 0);
        }

        [Test]
        public void GymInjureAthleteMethodShouldThrowExceptionWhenTryTOInjureInvalidAthlete()
        {
            Gym gym = new Gym("MyGym", 2);
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Name Surname"));
        }

        [Test]
        public void GymInjureAthleteMethodShouldWorkProperlyAndReturnTrue()
        {
            Gym gym = new Gym("MyGym", 2);
            Athlete athlete = new Athlete("Name Surname");
            gym.AddAthlete(athlete);
            gym.InjureAthlete("Name Surname");
            Assert.IsTrue(athlete.IsInjured);
        }

        [Test]
        public void GymInjureAthleteMethodShouldReturnFalce()
        {
            Gym gym = new Gym("MyGym", 2);
            Athlete athlete = new Athlete("Name Surname");
            gym.AddAthlete(athlete);
            Assert.IsFalse(athlete.IsInjured);
        }

        [Test]
        public void GymInjureAthleteMethodShouldReturnAthlete()
        {
            Gym gym = new Gym("MyGym", 2);
            Athlete athlete = new Athlete("Name Surname");
            gym.AddAthlete(athlete);
            Assert.AreEqual(athlete, gym.InjureAthlete("Name Surname"));
        }

        [Test]
        public void GymReportMethodShouldWorkProperly()
        {
            Gym gym = new Gym("MyGym", 2);
            Athlete athlete1 = new Athlete("NameOne Surname");
            Athlete athlete2 = new Athlete("NameTwo Surname");
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            string result = $"Active athletes at MyGym: NameOne Surname, NameTwo Surname";
            Assert.AreEqual(gym.Report(), result);
        }
    }
}
