using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Stores;


namespace Reservoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        // every time we add items or insert items or remove items from this collection our list view is going to automatically update
        private readonly ObservableCollection<ReservationViewModel> _reservations;

        // it's expose observable collection as an IEnumerable as same type reservation view models and
        // we'll call this reservations and it just be a property that points to our reservations field
        // I expose this as an enumerable is just for encapsulation so any class outside the reservation listing view model
        // can't just grab this property and add or remove items, however it pleases
        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ICommand LoadReservationsCommand { get; }
        public ICommand MakeReservationCommand { get; }

        public ReservationListingViewModel(Hotel hotel, NavigationService makeReservationNavigationService)
        {
            _reservations = new ObservableCollection<ReservationViewModel>();

            // initialize the MakeReservationCommand to be a new NavigateCommand, which we do successfully execute 
            LoadReservationsCommand = new LoadReservationsCommand(this, hotel);
            MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);

        }
        public static ReservationListingViewModel LoadViewModel(Hotel hotel, NavigationService makeReservationNavigationService)
        {
            ReservationListingViewModel viewModel = new ReservationListingViewModel(hotel, makeReservationNavigationService);

            viewModel.LoadReservationsCommand.Execute(null);

            return viewModel;
        }

        // create a method called UpdateReservations,and claer any existing reservations, which by default should be none,
        public void UpdateReservations(IEnumerable<Reservation> reservations)
        {
            _reservations.Clear();
            // iterate over all the reservations in our htel, so put hotel into a field in ReservationListingViweModel constructor
            foreach(Reservation reservation in reservations)
            {
                // I have this get all Reservations methos, and now we will simply map each reservation to ReservationViewModel,
                // and instantiate that pass in the Reservation 
                ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
                // add the view model to our observable collection of reservationViewModel
                _reservations.Add(reservationViewModel);
            }
        }
    }
}
