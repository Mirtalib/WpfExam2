using Source.Command;
using Source.Models;
using Source.Stores;
using Source.VeiwModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Source.UserControlVeiwModels
{
    public class MoviePublicityVeiwModel : BaseViewModel
    {
        private readonly NavigationStore? _navigationStore;
        private Movie Movie { get; set; }
        public ICommand? InformationAboutCommand { get; set; }
        
        public MoviePublicityVeiwModel(Movie movie, NavigationStore? navigationStore = null)
        {
            _navigationStore = navigationStore;
            InformationAboutCommand = new RelayCommand(ExecutInformationAboutCommand);
            Movie = movie;
        }

        private void ExecutInformationAboutCommand(object? obj)
        {
            MessageBox.Show("gdgfd");
        }

    }
}
