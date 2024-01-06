using Microsoft.EntityFrameworkCore;
using Reservoom.DBContext;
using Reservoom.Exceptions;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Services.ReservationConflictValidators;
using Reservoom.Services.ReservationCreators;
using Reservoom.Services.ReservationProviders;
using Reservoom.Stores;
using Reservoom.ViewModels;
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
        private const string CONNECTION_STRING = "Data Source=reservoom.db";

        // set Hotel for our application, that we'll use all throughout our application
        private readonly Hotel _hotel;
        // navigation store, this will be our single navigation store for the application,
        // and we can pass that down throughtout our application via the MainViewModel
        private readonly NavigationStore _navigationStore;
        private readonly ReservoomDbContextFactory _reservoomDbContextFactory;

        // initialize Hotel in the constructor 
        public App()
        {
            // to get our database to generate in the bin, we generate our database on application startup 
            _reservoomDbContextFactory = new ReservoomDbContextFactory(CONNECTION_STRING);
            IReservationProvider reservationProvider = new DatabaseReservationProvider(_reservoomDbContextFactory);
            IReservationCreator reservationCreator = new DatabaseReservationCreator(_reservoomDbContextFactory);
            IReservationConflictValidator reservationConflictValidator = new DatabaseReservationConflictValidator(_reservoomDbContextFactory);

            ReservationBook reservationBook = new ReservationBook(reservationProvider, reservationCreator, reservationConflictValidator);

            _hotel = new Hotel("SingletonSean Suites", reservationBook);
            // instantiate the navigation store
            _navigationStore = new NavigationStore();
        }

        // make list of reservation

        //  our data context for our main window is a main view model,
        //  so that means, on the main window we will have access to properties on our main viewmodel,
        //  such as this current viewmodel which we will bind to
        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
            using (ReservoomDBContext dbContext = new ReservoomDBContext(options))
            {
                dbContext.Database.Migrate();
            }



            // on our application startup we will set the currentViewModel to be the ReservationListingViewModel
            _navigationStore.CurrentViewModel = CreateReservationViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private MakeReservationViewModel CreateMakeReservationViewModel()
        {
            return new MakeReservationViewModel(_hotel, new NavigationService(_navigationStore, CreateReservationViewModel));
        }

        private ReservationListingViewModel CreateReservationViewModel()
        {
            return ReservationListingViewModel.LoadViewModel(_hotel,new NavigationService(_navigationStore, CreateMakeReservationViewModel));
        }
    }
}
