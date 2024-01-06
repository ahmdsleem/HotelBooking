using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.DTOs
{
    // DTO: Data Transfer Object, it's transfer data between our application and the database
    public class ReservationDTO
    {
        // decorate the primary key with [Key] attribute
        [Key]
        // primary key
        public Guid Id { get; set; }
        public int FloorNumber { get; set; }
        public int RoomNumber { get; set; }
        public string Username { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
