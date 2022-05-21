using System;

namespace Model
{
    public class RoomDetails
    {
      /// <summary>
      /// Gets and sets hotel Rooms
      /// </summary>
      public int RoomNumber { get; set;}

      /// <summary>
      /// Gets and Sets date of booing
      /// </summary>
      public DateTime BookingFrom { get; set; }

      /// <summary>
      /// Not in use currently
      /// </summary>
      public DateTime BookingTo { get; set; }

      /// <summary>
      /// Gets and Stes Guest Name
      /// </summary>
      public string Guest { get; set; }
      
      /// <summary>
      /// For fast retrival of free rooms
      /// </summary>
      public bool Isavailable { get; set; }
    }
}
