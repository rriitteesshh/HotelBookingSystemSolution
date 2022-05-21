using Hotel_Booking_System.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;


namespace Hotel_Booking_System
{
    public class BookingManager : IBookingManager
    {
        internal static IDictionary<int, ConcurrentBag<RoomDetails>> RoomDetailsCollection;

        public void AddBooking(string guest, int room, DateTime date)
        {
            try
            {
                CheckSeed();
                if (IsRoomAvailable(room, date, out ConcurrentBag<RoomDetails> rooms))
                {
                    RoomDetails roomObj = new RoomDetails
                    {
                        BookingFrom = date,
                        Guest = guest,
                        RoomNumber = room
                    };
                    rooms.Add(roomObj);
                }
                else
                {
                    throw new Exception("Room is alredy Booked!!");
                }
             
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }


        public bool IsRoomAvailable(int room, DateTime date)
        {
            CheckSeed();
            if (RoomDetailsCollection.TryGetValue(room, out ConcurrentBag<RoomDetails> value))
            {
                if (value == null)
                    return true;
                return !value.Any(rm => rm.BookingFrom.Date == date.Date);
            }
            return false;
        }

        private void CheckSeed()
        {
            if (RoomDetailsCollection == null)
                throw new Exception("Please seed your Hotel data");
        }

        private bool IsRoomAvailable(int room, DateTime date, out ConcurrentBag<RoomDetails> valueList)
        {
            if (RoomDetailsCollection.TryGetValue(room, out valueList))
            {
                if(valueList == null)
                {
                    valueList = new ConcurrentBag<RoomDetails>();
                    return true;
                }

                return !valueList.Any(rm => rm.BookingFrom.Date == date.Date);
            }           
                throw new Exception("Room does not exist!!");             
        }

        public IEnumerable<int> GetAvailableRooms(DateTime date)
        {
            List<int> availableRooms = new List<int>();
            CheckSeed();
            foreach (var elements in RoomDetailsCollection.Keys)
            {
               if(IsRoomAvailable(elements,date))
                {
                    availableRooms.Add(elements);
                }
            }
            return availableRooms;
        }

      
    }
}
