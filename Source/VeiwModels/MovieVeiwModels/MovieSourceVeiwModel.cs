using Source.Command;
using Source.Models;
using Source.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Text.Json;

namespace Source.VeiwModels.MovieVeiwModels
{
    public class MovieSourceVeiwModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private User User { get; set; } = new();
        public string MovieName { get; set; } = string.Empty;
        public ICommand MovieSourceCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public MovieSourceVeiwModel(NavigationStore navigationStore, User user)
        {
            _navigationStore = navigationStore;
            User = user;
            MovieSourceCommand = new RelayCommand(ExecuteMovieSourceCommand, CanExecuteMovieSourceCommand);
            CancelCommand = new RelayCommand(ExecuteCancelCommand);
        }

        private void ExecuteCancelCommand(object? obj)
            => _navigationStore.CurrentViewModel = new HomeVeiwModel(_navigationStore, User);

        private async void ExecuteMovieSourceCommand(object? obj)
        {
            // Enter the name of the movie below
            const string _apiKey = "580270e";
            const string _url = $"http://www.omdbapi.com/?apikey={_apiKey}";


            string search = $"{_url}&t={MovieName}";
            using HttpClient client = new();
            string jsonStr = await client.GetStringAsync(search);
            Movie movie = JsonSerializer.Deserialize<Movie>(jsonStr)!;

            if (movie?.Title is null)
            {
                MessageBox.Show("No Such Movie");
                return;
            }
            _navigationStore.CurrentViewModel = new InformationMovieVeiwModel(movie,_navigationStore, User);
        }

        private bool CanExecuteMovieSourceCommand(object? obj)
            =>!string.IsNullOrWhiteSpace(MovieName);

    }
}
