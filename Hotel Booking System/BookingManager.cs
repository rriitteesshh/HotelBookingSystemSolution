using Hotel_Booking_System.Interfaces;
using Model;
using System;
using System.Collections.Generic;

namespace Hotel_Booking_System
{
    public class BookingManager : IBookingManager
    {
        private static List<RoomDetails> roomdetails;

        public void AddBooking(string guest, int room, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> getAvailableRooms(DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool IsRoomAvailable(int room, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
