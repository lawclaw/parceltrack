using Coursework.business;
using Coursework.exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CWUnitTesting
{
    /// <summary>
    /// Unit test class on Courier class
    /// </summary>
    [TestClass]
    public class CourierTest
    {
        /// <summary>
        /// Tests adding parcel functionality
        /// </summary>
        [TestMethod]
        public void AddingParcel()
        {
            //Arrange
            Dictionary<string, Courier> couriers = new Dictionary<string, Courier>();
            WalkingCourier courier = new WalkingCourier("EH3", couriers);

            Parcel parcel = new Parcel("EH3", "1DY", "Edith Black, 21 High Street",courier.Id);
            int expectedParcels = 1;

            //Act
            courier.AddParcel(parcel);
            int actualParcels = courier.Parcels.Count;

            //Assert
            Assert.AreEqual(expectedParcels, actualParcels);

        }

        /// <summary>
        /// Tests removing parcel functionality
        /// </summary>
        [TestMethod]
        public void RemoveParcel()
        {
            //Arrange
            Dictionary<string, Courier> couriers = new Dictionary<string, Courier>();
            WalkingCourier courier = new WalkingCourier("EH3", couriers);

            Parcel parcel = new Parcel("EH3", "1DY", "Edith Black, 21 High Street", courier.Id);
            int expectedParcels = 0;

            //Act
            courier.AddParcel(parcel);
            courier.RemoveParcel(parcel);
            int actualParcels = courier.Parcels.Count;

            //Assert
            Assert.AreEqual(expectedParcels, actualParcels);
        }

        /// <summary>
        /// Tests FullCourierException
        /// </summary>
        [TestMethod]
        public void FullCourier()
        {
            //Arrange
            Dictionary<string, Courier> couriers = new Dictionary<string, Courier>();
            WalkingCourier courier = new WalkingCourier("EH3", couriers);

            Parcel parcel = new Parcel("EH3", "1DY", "Edith Black, 21 High Street", courier.Id);

            //Act
            courier.AddParcel(parcel);
            courier.AddParcel(parcel);
            courier.AddParcel(parcel);
            courier.AddParcel(parcel);
            courier.AddParcel(parcel);

            //Assert
            try
            {
                courier.AddParcel(parcel);
                Assert.Fail("no exception thrown");
            } catch (Exception ex)
            {
                Assert.IsTrue(ex is FullCourierException);
            }
        }

        /// <summary>
        /// Tests ToCSV()
        /// </summary>
        [TestMethod]
        public void CSVTest()
        {
            //Arrange
            Dictionary<string, Courier> couriers = new Dictionary<string, Courier>();
            WalkingCourier courier = new WalkingCourier("EH3", couriers);

            Parcel parcel = new Parcel("EH3", "1DY", "Edith Black, 21 High Street", courier.Id);

            //Act
            string expected = $"{courier.GetType().Name},{courier.Id},EH3";

            //Assert
            Assert.AreEqual(expected, courier.ToCSV());
            
        }

        /// <summary>
        /// Tests for constructor when area is invalid  
        /// </summary>
        [TestMethod] 
        public void ConstructorTest()
        {
            //Arrange
            Dictionary<string, Courier> couriers = new Dictionary<string, Courier>();

            try
            {
                WalkingCourier courier = new WalkingCourier("EH5", couriers);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is InvalidAreaException);
            }

        }

    }
}
