using NUnit.Framework;
using System;
using CarManager;

namespace CarManager.Tests
{
    [TestFixture]
    public class CarTests
    {


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            //public Car(string make, string model, double fuelConsumption, double fuelCapacity)
            string make = "aaa";
            string model = "bbb";
            double fuelConsumption = 5;
            double fuelCapacity = 40;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void ModelShouldThrowArgExWhenNameIsNull()
        {
            string make = "aaa";
            string model = null;
            double fuelConsumption = 5;
            double fuelCapacity = 40;
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void MakeShouldThrowArgExWhenNameIsNull()
        {
            string make = null;
            string model = "aaa";
            double fuelConsumption = 5;
            double fuelCapacity = 40;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void FuelConsumptionShouldThrowArgExWhenIsBellowZero()
        {
            double fuelConsumption = -5;
            Assert.Throws<ArgumentException>(() => new Car("aaa", "bbb", fuelConsumption, 50));
        }

        [Test]
        public void FuelConsumptionShouldThrowArgExWhenIsZero()
        {
            string make = "nnnnn";
            string model = "aaa";
            double fuelConsumption = 0;
            double fuelCapacity = 40;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void FuelCapacityShouldThrowArgExWhenIsZero()
        {
            var fuelCapacity = 0;
            Assert.Throws<ArgumentException>(() => new Car("aaa", "bbb", 5, fuelCapacity));
        }

        [Test]
        public void FuelCapacityShouldThrowArgExWhenIsBellowZero()
        {
            var fuelCapacity = -30;
            Assert.Throws<ArgumentException>(() => new Car("aaa", "bbb", 5, fuelCapacity));
        }


        [TestCase(null,"aaa",4,100)]
        [TestCase("","aaa",4,100)]
        [TestCase("aaa",null,4,100)]
        [TestCase("aaa","",4,100)]
        [TestCase("aaa","bbb",-4,100)]
        [TestCase("aaa","bbb",0,100)]
        [TestCase("aaa","bbb",4,-100)]
        [TestCase("aaa","bbb",4,0)]
        public void ValidateAllProperties(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }


        [Test]
        public void ShouldRefuelNormally()
        {
            var fuelCapacity = 50;
            Car car = new Car("aaa", "bbb", 5, fuelCapacity);           
            car.Refuel(30);
            Assert.AreEqual(30, car.FuelAmount);
        }

        [Test]
        public void ShouldRefuelUntillTotalFuelCapacity()
        {
            var fuelCapacity = 50;
            Car car = new Car("aaa", "bbb", 5, fuelCapacity);            
            car.Refuel(60);
            Assert.AreEqual(50, car.FuelAmount);
        }

        [Test]        
        public void ShouldRefuelThrowArgExWhenInputAmountIsBellowZero(double inputAmount)
        {
            Car car = new Car("aaa", "bbb", 5, 50);           
            Assert.Throws<ArgumentException>(() => car.Refuel(-6));
        }

        [Test]
        public void ShouldDriveNormally()
        {
            Car car = new Car("Vw", "Golf", 2, 100);
            car.Drive(400);
            Assert.AreEqual(, car.FuelAmount);
        }

        [Test]
        public void DriveShouldThrowInvalidOperationExceptionWhenFuelAmountIsNotEnough()
        {
            Car car = new Car("Vw", "Golf", 2, 100);
            Assert.Throws<InvalidOperationException>(() => car.Drive(200));
        }
    }

}
