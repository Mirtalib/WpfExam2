using Source.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.VeiwModels
{
    internal class MainVeiwModel :BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        public BaseViewModel? CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainVeiwModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            navigationStore.CurrentViewModelChanged += NavigationStore_CurrentViewModelChanged1; ;
        }

        private void NavigationStore_CurrentViewModelChanged1()
            => NotifyPropertyChanged(nameof(CurrentViewModel));


    }
}
