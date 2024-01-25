using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase
    {
        /// <summary>
        /// all property Binded with UI
        /// </summary>
        // scaffolds out a property and automatically calls one property changed for the property name
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        // scaffolds out a property and automatically calls one property changed for the property floor number
        private int _floorNumber;

        public int FloorNumber
        {
            get { return _floorNumber; }
            set 
            {
                _floorNumber = value;
                OnPropertyChanged(nameof(FloorNumber));
            }
        }

        // scaffolds out a property and automatically calls one property changed for the property room number
        private int _roomNumber;

        public int RoomNumber
        {
            get
            {
                return _roomNumber; 
            }
            set
            { 
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }
        private DateTime _startDate = new DateTime(2024, 1, 1);

        public DateTime StartDate
        {
            get { return _startDate; }
            set 
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }
        private DateTime _endDate = new DateTime(2024, 1, 8);
        private NavigationStore navigationStore;
        private NavigationService reservationViewNavigationService;

        public DateTime EndDate
        {
            get { return _endDate; }
            set 
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        // this commands binding to view UI commands
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get;}

        public MakeReservationViewModel(HotelStore hotel, NavigationService reservationViewNavigationService)
        {
            // pass the MkeReservationViewModel to the MakeReservationCommand
            SubmitCommand = new MakeReservationCommand(this, hotel, reservationViewNavigationService);
            // I want my submit button and my cancel button to both take me back to the ReservationView, so I will use the same NavigationService 
            CancelCommand = new NavigateCommand(reservationViewNavigationService);
        }
    }
}
