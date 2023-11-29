using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class RoomID
    {
        public int FloorNumber { get; }
        public int RoomNumber { get; }

        public RoomID(int floorNumber, int roomNumber)
        {
            FloorNumber = floorNumber;
            RoomNumber = roomNumber;
        }
        public override string ToString()
        {
            return $"{FloorNumber}{RoomNumber}";
        }
        public override bool Equals(object obj)
        {
                return obj is RoomID roomID &&
                    FloorNumber == roomID.FloorNumber &&
                    RoomNumber == roomID.RoomNumber;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(FloorNumber, RoomNumber);
        }

        // we're going to do override the equals operator for the RoomId
        public static bool operator ==(RoomID roomId1, RoomID roomId2)
        {
            // null checks here so if they're both null then we will return true.
            if (roomId1 is null && roomId2 is null)
            {
                return true;
            }

            return !(roomId1 is null) && roomId2.Equals(roomId2);
        }

        public static bool operator !=(RoomID roomId1, RoomID roomId2)
        {
            return !(roomId1 == roomId2);
        }
    }
}
