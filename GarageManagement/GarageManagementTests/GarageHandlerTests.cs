using Microsoft.VisualStudio.TestTools.UnitTesting;
using GarageManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageManagement.Vehicles;

namespace GarageManagement.Tests
{
    [TestClass()]
    public class GarageHandlerTests
    {
        [TestMethod()]
        public void ParkVehicleWithSlotSucessTest()
        {
            //arrange
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Garage<Vehicle> gr = gh.CreateGarage("test", "addr", 100);

            Vehicle v = new Car("111", "black", 4, "gas");

            //act
            string actual = gh.ParkVehicle(gr, v, 1);
            string expected = "You parked successfully at slot 1" +
                "\nName: test" +
                "\nAdress: addr" +
                "\nMaximum capacity: 100" +
                "\nNumber of ocuppied slots: 1" +
                "\nNumber of empty slots: 99";

            Console.WriteLine(actual);

            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void ParkVehicleWithoutSlotSucessTest()
        {
            //arrange
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Garage<Vehicle> gr = gh.CreateGarage("test", "addr", 100);

            Vehicle v = new Car("111", "black", 4, "gas");

            //act
            string actual = gh.ParkVehicle(gr, v, 0);
            string expected = "You parked successfully at slot 1" +
                "\nName: test" +
                "\nAdress: addr" +
                "\nMaximum capacity: 100" +
                "\nNumber of ocuppied slots: 1" +
                "\nNumber of empty slots: 99";

            Console.WriteLine(actual);

            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void ParkMultipleVehicleSucessTest()
        {
            //arrange
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Garage<Vehicle> gr = gh.CreateGarage("test", "addr", 100);

            Vehicle v1 = new Airplane("111", "black", 4, 4);
            Vehicle v2 = new Boat("222", "white", 5, 8);
            Vehicle v3 = new Bus("333", "black", 6, 9);
            Vehicle v4 = new Car("444", "black", 7, "gas");
            Vehicle v5 = new Motorcycle("555", "black", 8, 120);

            //act
            string actual1 = gh.ParkVehicle(gr, v1, 1);
            string expected1 = "You parked successfully at slot 1" +
                "\nName: test" +
                "\nAdress: addr" +
                "\nMaximum capacity: 100" +
                "\nNumber of ocuppied slots: 1" +
                "\nNumber of empty slots: 99";

            string actual2 = gh.ParkVehicle(gr, v2, 2);
            string expected2 = "You parked successfully at slot 2" +
                "\nName: test" +
                "\nAdress: addr" +
                "\nMaximum capacity: 100" +
                "\nNumber of ocuppied slots: 2" +
                "\nNumber of empty slots: 98";

            string actual3 = gh.ParkVehicle(gr, v3, 4);
            string expected3 = "You parked successfully at slot 4" +
                "\nName: test" +
                "\nAdress: addr" +
                "\nMaximum capacity: 100" +
                "\nNumber of ocuppied slots: 3" +
                "\nNumber of empty slots: 97";

            string actual4 = gh.ParkVehicle(gr, v4, 0);
            string expected4 = "You parked successfully at slot 3" +
                "\nName: test" +
                "\nAdress: addr" +
                "\nMaximum capacity: 100" +
                "\nNumber of ocuppied slots: 4" +
                "\nNumber of empty slots: 96";

            string actual5 = gh.ParkVehicle(gr, v5, 0);
            string expected5 = "You parked successfully at slot 5" +
                "\nName: test" +
                "\nAdress: addr" +
                "\nMaximum capacity: 100" +
                "\nNumber of ocuppied slots: 5" +
                "\nNumber of empty slots: 95";

            Console.WriteLine(actual1);
            Console.WriteLine(actual2);
            Console.WriteLine(actual3);
            Console.WriteLine(actual4);
            Console.WriteLine(actual5);

            //assert
            Assert.AreEqual(actual1, expected1);
            Assert.AreEqual(actual2, expected2);
            Assert.AreEqual(actual3, expected3);
            Assert.AreEqual(actual4, expected4);
            Assert.AreEqual(actual5, expected5);
        }

        [TestMethod()]
        public void ParkVehicleBelowZeroTest()
        {
            //arrange
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Garage<Vehicle> gr = gh.CreateGarage("test", "addr", 100);

            Vehicle v = new Car("111", "black", 4, "gas");

            //act
            string actual = gh.ParkVehicle(gr, v, -1);
            string expected = "The position you want to park is not existed";

            Console.WriteLine(actual);

            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void ParkVehicleAboveCapacityTest()
        {
            //arrange
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Garage<Vehicle> gr = gh.CreateGarage("test", "addr", 100);

            Vehicle v = new Car("111", "black", 4, "gas");

            //act
            string actual = gh.ParkVehicle(gr, v, 200);
            string expected = "The position you want to park is not existed";

            Console.WriteLine(actual);

            //assert
            Assert.AreEqual(actual, expected);
        }


        [TestMethod()]
        public void ParkVehicleUnemptyTest()
        {
            //arrange
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Garage<Vehicle> gr = gh.CreateGarage("test", "addr", 100);

            Vehicle v1 = new Car("111", "black", 4, "gas");
            Vehicle v2 = new Car("222", "black", 4, "gas");

            //act
            string actual = gh.ParkVehicle(gr, v1, 5);
            actual = gh.ParkVehicle(gr, v2, 5);
            string expected = "The slot you want to park is not empty.";

            Console.WriteLine(actual);

            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void ParkVehicleFullTest()
        {
            //arrange
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Garage<Vehicle> gr = gh.CreateGarage("test", "addr", 1);

            Vehicle v = new Car("111", "black", 4, "gas");
            Vehicle v1 = new Car("111", "black", 4, "gas");

            //act
            string actual = gh.ParkVehicle(gr, v, 0);
            actual = gh.ParkVehicle(gr, v1, 0);
            string expected = "The garage is full";

            Console.WriteLine(actual);

            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void UnParkVehicleWithSlotSucessTest()
        {
            //arrange
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Garage<Vehicle> gr = gh.CreateGarage("test", "addr", 100);

            Vehicle v = new Car("111", "black", 4, "gas");

            //act
            gh.ParkVehicle(gr, v, 1);
            string actual = gh.UnParkVehicle(gr, null, 1);
            string expected = "You unparked successfully at slot 1" +
                "\nName: test" +
                "\nAdress: addr" +
                "\nMaximum capacity: 100" +
                "\nNumber of ocuppied slots: 0" +
                "\nNumber of empty slots: 100";

            Console.WriteLine(actual);

            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void UnParkVehicleWithRegSucessTest()
        {
            //arrange
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Garage<Vehicle> gr = gh.CreateGarage("test", "addr", 100);

            Vehicle v = new Car("111", "black", 4, "gas");

            //act
            string actual1= gh.ParkVehicle(gr, v, 5);
            string actual = gh.UnParkVehicle(gr, "111", 0);
            string expected = "You unparked successfully at slot 5" +
                "\nName: test" +
                "\nAdress: addr" +
                "\nMaximum capacity: 100" +
                "\nNumber of ocuppied slots: 0" +
                "\nNumber of empty slots: 100";

            Console.WriteLine(actual1);

            //assert
            Assert.AreEqual(actual, expected);
        }


        [TestMethod()]
        public void UnParkVehicleBelowZeroTest()
        {
            //arrange
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Garage<Vehicle> gr = gh.CreateGarage("test", "addr", 100);

            //act
            string actual = gh.UnParkVehicle(gr, null, -1);
            string expected = "The position you want to unpark is not existed";

            Console.WriteLine(actual);

            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void UnParkVehicleAboveCapacityTest()
        {
            //arrange
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Garage<Vehicle> gr = gh.CreateGarage("test", "addr", 100);

            //act
            string actual = gh.UnParkVehicle(gr, null, 200);
            string expected = "The position you want to unpark is not existed";

            Console.WriteLine(actual);

            //assert
            Assert.AreEqual(actual, expected);
        }


        [TestMethod()]
        public void UnParkVehicleEmptyTest()
        {
            //arrange
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Garage<Vehicle> gr = gh.CreateGarage("test", "addr", 100);

            //act
            string actual = gh.UnParkVehicle(gr, null, 1);
            string expected = "The slot you want to unpark is empty.";

            Console.WriteLine(actual);

            //assert
            Assert.AreEqual(actual, expected);
        }

    }
}