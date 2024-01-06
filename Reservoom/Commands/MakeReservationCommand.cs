using Reservoom.Exceptions;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Reservoom.Commands
{
    // this command for submitting a new reservation on the MakeReservationView
    public class MakeReservationCommand : AsyncCommandBase
    {
        private readonly MakeReservationViewModel _makeReservationViewModel;
        // I make _hotel field to pass into MakeReservationCommand
        private readonly Hotel _hotel;
        private readonly NavigationService _reservationViewNavigationService;

        // initialize MakeReservationCommand and pass hotel through it.
        // in the MakeReservationCommand we add a NavigationService (through the constructor)
        // and call it a reservationViewNavigationService (because I want to anvigate to),
        // and put that into a field
        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel, NavigationService reservationViewNavigationService)
        {
            _makeReservationViewModel = makeReservationViewModel;
            _hotel = hotel;
            _reservationViewNavigationService = reservationViewNavigationService;
            // to subscribe to PropertyChanged on our viewmodel
            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            // check if our MakeReservationViewModel has a username, and we want to make sure that the username is not null or empty.
            // if username is null or empty the submit button will be disable
            return !string.IsNullOrEmpty(_makeReservationViewModel.Username) &&
                _makeReservationViewModel.FloorNumber > 0 && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Reservation reservation = new Reservation(
                new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber),
                _makeReservationViewModel.Username,
                _makeReservationViewModel.StartDate,
                _makeReservationViewModel.EndDate
                );

            try
            {
                await _hotel.MakeReservation(reservation);

                MessageBox.Show("Successfully reserved room", "Success",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                    );

                // when we make the reservation we will take our navigation service and navigate.
                _reservationViewNavigationService.Navigate();
            }
            catch (ReservationConflictException)
            {
                MessageBox.Show("This room is already taken.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to make reservation.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // check if the property name that changed was the username property or FloorNumber is great than zero by using (nameOf())
            // and pass in the name of the MakeReservationViewModel username property,
            // and if the username property did change that means the view has to re-query,
            // this can execute method, because our username has changed,
            // so we're going to raise canExecuteChanged by calling OnCanExecutedChanged(), which we defined on CommandBase
            if (e.PropertyName == nameof(MakeReservationViewModel.Username) ||
                e.PropertyName == nameof(MakeReservationViewModel.FloorNumber))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
