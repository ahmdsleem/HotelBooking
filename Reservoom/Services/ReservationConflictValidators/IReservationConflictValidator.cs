using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Services.ReservationConflictValidators
{
    public interface IReservationConflictValidator
    {
        // method to test the reservation if it conflict or not 
        Task<Reservation> GetConflictingReservation(Reservation reservation);
    }
}
