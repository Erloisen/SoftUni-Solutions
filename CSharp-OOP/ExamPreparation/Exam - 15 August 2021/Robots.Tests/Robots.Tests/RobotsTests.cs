namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;
        private const string name = "Robot";
        private const int maximumBattery = 1;
        private const int capacity = 2;

        [SetUp]
        public void SetUp()
        {
            this.robot = new Robot(name, maximumBattery);
            this.robotManager = new RobotManager(capacity);
            this.robotManager.Add(robot);
        }

        [Test]
        public void CtorRobotShouldSetNameAndMaximumBattery()
        {
            int battery = 1;
            robot.Battery = battery;
            Assert.That(name, Is.EqualTo(robot.Name));
            Assert.That(maximumBattery, Is.EqualTo(robot.MaximumBattery));
            Assert.That(battery, Is.EqualTo(robot.Battery));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void CtroRobotManagerShoudSetCapacity(int capacity)
        {
            var robotManager = new RobotManager(capacity);
            Assert.That(capacity, Is.EqualTo(robotManager.Capacity));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void PropRobotManagerCapacityShouldThrowArgumentExceptionWhenIsBelowZero(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(capacity));
        }

        [Test]
        public void MethodCountShouldCountRobotsInCollectionOfRobotsManager()
        {
            Assert.That(1, Is.EqualTo(robotManager.Count));
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenThereIsSuchRobotName()
        {
            var robots = new RobotManager(capacity);
            robots.Add(this.robot);
            Assert.Throws<InvalidOperationException>(() => robots.Add(new Robot("Robot", 1)));
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenThereIsNotEnoughCapacity()
        {
            var robots = new RobotManager(capacity);
            robotManager.Add(new Robot("Robot1", 1));
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("Robot2", 1)));
        }

        [Test]
        public void AddMethodShouldAddRobotsToCollectionOfRobots()
        {
            Assert.That(1, Is.EqualTo(robotManager.Count));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenThereIsNotRObotWithTheNameTryingToRemove()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("Robot2"));
        }

        [Test]
        public void RemoveMethodShouldRemoveRobotsFromCollection()
        {
            int expectedCount = 0;
            robotManager.Remove(this.robot.Name);
            Assert.That(expectedCount, Is.EqualTo(robotManager.Count));
        }

        [Test]
        public void WorkMethodShouldThrowExceprionWhenThereIsNoRobotInCollectionWithThatName()
        {
            int batteryUsage = 5;
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Robot1", "DoJob", batteryUsage));
        }

        [Test]
        public void WorkMethodShouldThrowExceprionWhenBarretyUsageIsMoreThanBattery()
        {
            int batteryUsage = 5;
            Assert.Throws<InvalidOperationException>(() => robotManager.Work(this.robot.Name, "DoJob", batteryUsage));
        }

        [Test]
        public void WorkMethodShouldDecreasesRobotsBatteryByBatteryUsage()
        {
            int batteryUsage = 1;
            robotManager.Work(this.robot.Name, "DoJob", batteryUsage);
            Assert.That(0, Is.EqualTo(robot.Battery));
        }

        [Test]
        public void ChargeMethodShouldThrowExceprionWhenThereIsNoRobotInCollectionWithThatName()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("Robot1"));
        }

        [Test]
        public void ChargeMethodShouldSetMaximumBatteryToBattery()
        {
            int expectedResult = this.robot.MaximumBattery;
            robotManager.Work(this.robot.Name, "DoJob", 1);
            robotManager.Charge(this.robot.Name);
            Assert.That(expectedResult, Is.EqualTo(robot.Battery));
        }
    }
}
