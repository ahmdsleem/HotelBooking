using Reservoom.Stores;
using Reservoom.ViewModels;
using Reservoom.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Commands
{
    // general navigate command, we want that button to navigate to the MakeReservationView 
    public class NavigateCommand : CommandBase
    {
        /// <summary>
        /// when click Make Reservation button go to reservation page,
        /// we add navigationStore here to automatically change the current ViewModel,
        /// so we can get that through the constructor.
        /// Codes have been moved to NavigationService.cs class in Services file
        /// </summary>
        /// 

        // take a NavigationService, and import the one from Reservoom.Services, not from System
        private readonly NavigationService _navigationService;
        // get the navigate through the constructor
        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            // to navigate, we have to take our _navigationService and navigate.
            _navigationService.Navigate();
        }
    }
}
