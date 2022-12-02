using Source.Command;
using Source.Models;
using Source.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Source.VeiwModels.MovieVeiwModels
{
    public class InformationMovieVeiwModel:BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        public Movie Movie { get; set; }
        private User User { get; set; } = new();
        public ICommand AddMovieCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public InformationMovieVeiwModel(Movie movie, NavigationStore navigationStore, User user)
        {
            _navigationStore = navigationStore;
            Movie = movie;
            User = user;
            AddMovieCommand = new RelayCommand(ExecuteAddMovieCommand);
            CancelCommand = new RelayCommand(ExecuteCancelCommand);
        }

        private void ExecuteAddMovieCommand(object? obj)
        {
            User.Movies.Add(Movie);
            _navigationStore.CurrentViewModel = new MovieSourceVeiwModel(_navigationStore, User);
        }

        private void ExecuteCancelCommand(object? obj)
            => _navigationStore.CurrentViewModel = new MovieSourceVeiwModel(_navigationStore, User);
    }
}
