using System;
using System.Collections.Generic;
using System.Text;

namespace praktika.Model
{
    public class booking_wrnt_details_Model
    {
        public booking_wrnt_details_Model(booking_wrnt_details_Model bookingDetails)
        {
            this.userId = bookingDetails.userId;
            this.checkInDate = bookingDetails.checkInDate;
            this.checkOutDate = bookingDetails.checkOutDate;
            this.roomType = bookingDetails.roomType;
        }
        public booking_wrnt_details_Model(int userId, DateTime checkInDate, DateTime checkOutDate, string roomType)
        {
            this.userId = userId;
            this.checkInDate = checkInDate;
            this.checkOutDate = checkOutDate;
            this.roomType = roomType;
        }

        public int userId { get; }
        public DateTime checkInDate { get; }
        public DateTime checkOutDate { get; }
        public string roomType { get; }
    }

    public class booking_wred_details_Model : booking_wrnt_details_Model
    {
        booking_wred_details_Model(booking_wrnt_details_Model bookingDetails, int id)
            :base(bookingDetails)
        {
            this.id = id;
        }

        public booking_wred_details_Model(int id, int userId, DateTime checkInDate, DateTime checkOutDate, string roomType, int RoomNumber)
            :base(userId, checkInDate, checkOutDate, roomType)
        {
            this.id = id;
            this.RoomNumber = RoomNumber;
        }
        
        public int id { get; }
        public int RoomNumber { get; }
    }
}
