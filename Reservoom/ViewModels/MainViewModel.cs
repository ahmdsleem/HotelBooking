using Reservoom.Models;
using Reservoom.Stores;
using Reservoom.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        // MainViewModel needs the navigation store, so that we know what view to display on our Mainwindow,
        // so we get that navigation store as a field in our MainViewModel, so import our _navigationStore
        private readonly NavigationStore _navigationStore;
        // rather than storing the current ViewModel state on our MainViewModel,
        // we have it in this third party kind of mediator like object,
        // which will allow us to change the current ViewModel for the application from anywhere.
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            // subscribe Action event in NavigationStore
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
