using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged // an interface that automatically hooks into our viewmodel ant it will be abe to raise an event on this interface
    {
        public event PropertyChangedEventHandler PropertyChanged;   // tell the ui what bindings to update 

        // call this method to tell UI whenever a property value has changed so that our views can re-grab the property value and update the UI
        protected void OnPropertyChanged(string propertyName)
        {
            //if anythins is subscribed to it, we will invoke it with the sender as this viewmodel and some property changed envent args
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // to clean up ViewModel
        public virtual void Dispose() { }
    }
}
