using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Stores
{
    public class HotelStore
    {
        private readonly Hotel _hotel;
        private readonly Lazy<Task> _initializeLazy;
        private readonly List<Reservation> _reservations;

        public IEnumerable<Reservation> Reservations => _reservations;

        // event for Reactivity, to tell our ReservationListingViewModel about the new reservation
        public event Action<Reservation> ReservationMade;

        public HotelStore(Hotel hotel) 
        {
            _hotel = hotel;
            // lazy make sure that our initialization only happens once
            _initializeLazy = new Lazy<Task>(Initialize);
            
            _reservations = new List<Reservation>();
        }

        public async Task Load()
        {
            // Initialze Task wrapped in the lazy every time we await this value, we are only goint to initialize once
            await _initializeLazy.Value;
        }
        // to tell our hotel store about the new reservation that we made,
        // so we can add it to list,
        // and then we really won't to hit the database 
        public async Task MakeReservation(Reservation reservation)
        {
            // logic to make that reservation in the database, and that directly goes through our _hotel.MakeReservation() method
            await _hotel.MakeReservation(reservation);

            // make that reservation in the database, but first we add this reservation to our list of in memory reservations
            _reservations.Add(reservation);

            OnReservationMade(reservation);
        }

        private void OnReservationMade(Reservation reservation)
        {
            ReservationMade?.Invoke(reservation);
        }

        // what we want to execute when we execute our lazy
        private async Task Initialize()
        {
            IEnumerable<Reservation> reservations = await _hotel.GetAllReservations();

            _reservations.Clear();
            _reservations.AddRange(reservations);
        }
    }
}
