using Reservoom.Exceptions;
using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Reservoom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // make list of reservation
        protected override void OnStartup(StartupEventArgs e)
        {
            Hotel hotel = new Hotel("SingletonSean Suites");

            try
            {
                hotel.MakeReservation(new Reservation(
                new RoomID(1, 3),
                "SingletonSean",
                new DateTime(2000, 1, 1),    // for start time
                new DateTime(2000, 1, 2)     // for end time
                ));

                hotel.MakeReservation(new Reservation(
                    new RoomID(1, 3),
                    "SingletonSean",
                    new DateTime(2000, 1, 1),    // for start time
                    new DateTime(2000, 1, 4)     // for end time
                    ));
            }
            catch (ReservationConflictException ex)
            {

                throw;
            }


            IEnumerable<Reservation> reservations = hotel.GetReservationsForUser("SingletonSean");

            base.OnStartup(e);
        }
    }
}
