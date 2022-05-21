using Hotel_Booking_System;
using Hotel_Booking_System.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingSystem.Test
{
    [TestClass]
    public class BookingManagerTest
    {
        private IBookingManager _bookingManager;

        [TestInitialize]
        public void Setup()
        {
            BookingManager.RoomDetailsCollection = new Dictionary<int, ConcurrentBag<RoomDetails>>();
            this._bookingManager = new BookingManager();

            ConcurrentBag<RoomDetails> rooms201 = new ConcurrentBag<RoomDetails>();
            var room201 = new RoomDetails
            {
                BookingFrom = System.DateTime.Today,
                Guest = "Test1",
                RoomNumber = 201
            };
            rooms201.Add(room201);
            BookingManager.RoomDetailsCollection.Add(201, rooms201);

            ConcurrentBag<RoomDetails> rooms202 = new ConcurrentBag<RoomDetails>();
            var room202 = new RoomDetails
            {
                BookingFrom = DateTime.Today,
                Guest = "Test2",
                RoomNumber = 202
            };
            rooms202.Add(room202);
            BookingManager.RoomDetailsCollection.Add(202, rooms202);

            ConcurrentBag<RoomDetails> rooms203 = new ConcurrentBag<RoomDetails>();
            var room203 = new RoomDetails
            {
                BookingFrom = DateTime.Today,
                Guest = "Test3",
                RoomNumber = 203
            };
            rooms203.Add(room203);
            BookingManager.RoomDetailsCollection.Add(203, rooms203);

            ConcurrentBag<RoomDetails> rooms204 = new ConcurrentBag<RoomDetails>();
            var room204 = new RoomDetails
            {
                BookingFrom = DateTime.Today,
                Guest = "Test4",
                RoomNumber = 204
            };
            rooms204.Add(room204);
            BookingManager.RoomDetailsCollection.Add(204, rooms204);

            ConcurrentBag<RoomDetails> rooms205 = new ConcurrentBag<RoomDetails>();
            var room205 = new RoomDetails
            {
                BookingFrom = DateTime.Today,
                Guest = "Test5",
                RoomNumber = 205
            };
            rooms205.Add(room205);
            BookingManager.RoomDetailsCollection.Add(205, rooms205);

            BookingManager.RoomDetailsCollection.Add(206, null);
        }

        [TestMethod]
        public void Test_IsRoomAvailable_1_True()
        {
            var bookingDay = new DateTime(2012, 3, 28);
            bool available =_bookingManager.IsRoomAvailable(201, bookingDay);
            Assert.IsTrue(available);
        }

        [TestMethod]
        public void Test_IsRoomAvailable_2_True()
        {
            var bookingDay = new DateTime(2012, 3, 28);
            bool available = _bookingManager.IsRoomAvailable(206, bookingDay);
            Assert.IsTrue(available);
        }
        
        [TestMethod]
        public void Test_IsRoomAvailable_False()
        {
            var bookingDay = DateTime.Now;
            bool available = _bookingManager.IsRoomAvailable(202, bookingDay);
            Assert.IsFalse(available);
        }

        [TestMethod]
        public void Test_AddBooking_Success()
        {
            var bookingDay = new DateTime(2022, 6, 25);
            _bookingManager.AddBooking("Test", 203, bookingDay);
            bool available = _bookingManager.IsRoomAvailable(203, bookingDay);
            Assert.IsFalse(available);
        }

        [TestMethod]
        public void Test_AddBooking_Exception()
        {
            try
            {
                var bookingDay = DateTime.Now;
                _bookingManager.AddBooking("Test", 204, bookingDay);
            }
            catch(Exception ex)
            {
                Assert.AreSame("Room is alredy Booked!!", ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetAvailableRooms_Count6()
        {
            var bookingDay = new DateTime(2027, 6, 25);
            var counter = _bookingManager.GetAvailableRooms(bookingDay);
            Assert.AreEqual(counter.Count(), 6);
        }

        [TestMethod]
        public void Test_GetAvailableRooms_Count1()
        {
            var bookingDay =DateTime.Now;
            var counter = _bookingManager.GetAvailableRooms(bookingDay);
            Assert.AreEqual(counter.Count(), 1);
        }
    }
}
