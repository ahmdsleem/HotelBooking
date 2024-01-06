using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Services.ReservationProviders
{
    // I want to depend on interfaces throughout my models,
    // so I'm not directly dpendent on the database,
    // and it will also make unit testing possible.
    public interface IReservationProvider
    {
        // task give us back a collection of reservations.
        Task<IEnumerable<Reservation>> GetAllReservations();
    }
}
