using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Stores
{
    public class NavigationStore
    {
        // backing field for ViewModelBase property
        private ViewModelBase _currentViewModel;
        // Store the current viweModel for our application
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OncurrentViewModelChanged();
            }
        }
        // minet 6
        private void OncurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
        // our navigation store is going to have to notify the MainViewModel when the CurrentViewModel changes by the Action event.
        public event Action CurrentViewModelChanged;
    }
}
