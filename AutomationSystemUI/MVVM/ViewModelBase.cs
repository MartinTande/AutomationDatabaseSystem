using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace AutomationSystemUI.MVVM
{
    // Only class implementing the INotifyPropertyChanged interface, all other View models inherits from this base class
    // Use OnPropertyChanged() on any property we want to update between view and viewmodel
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
