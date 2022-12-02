using Source.Command;
using Source.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Source.User_Conteol;
using Source.Models;
using Source.VeiwModels.MovieVeiwModels;
using System.Runtime.CompilerServices;
using Source.Veiws;
using Source.Repositories.Contexts;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Source.UserControlVeiwModels;

namespace Source.VeiwModels;

public class HomeVeiwModel :BaseViewModel
{
    private readonly NavigationStore _navigationStore;

    private User User { get; set; } = new();
    public string MovieName { get; set; } = string.Empty;
    public ICommand MoviesTextChangedCommand { get; set; }
    public ICommand StartSetting { get; set; }
    public ICommand AddMovieCommand { get; set; }
    public ListBox listBox { get; set; } = new();

    public HomeVeiwModel(NavigationStore navigationStore, User user)
    {
        _navigationStore = navigationStore;
        User = user;




        foreach (var item in user.Movies)
        {
            if (item is null)
                return;
            var movie = new MoviePublicity();
            movie.ImageMovie.Source = new BitmapImage(new Uri(item.Poster, UriKind.RelativeOrAbsolute));
            movie.MovieName.Text = item.Title;
            listBox.Items.Add(movie);
        }
        StartSetting = new RelayCommand(ExecuteStartSetting);
        MoviesTextChangedCommand = new RelayCommand(ExecuteMoviesTextChangedCommand);
        AddMovieCommand = new RelayCommand(ExecutAddMovieCommand);
    }

    private void ExecutAddMovieCommand(object? obj)
        => _navigationStore.CurrentViewModel = new MovieSourceVeiwModel(_navigationStore, User);

    private void ExecuteStartSetting(object? obj)
        => _navigationStore.CurrentViewModel = new ProfileVeiwModel(_navigationStore,User);


    private void ExecuteMoviesTextChangedCommand(object? obj)
    {
        foreach (MoviePublicity item in listBox.Items)
        {
            if (MovieName.Length == 0)
                item.Visibility = Visibility.Visible;
            if (!item.MovieName.Text.ToUpper().Contains(MovieName.ToUpper()))
                item.Visibility = Visibility.Collapsed;
        }
    }
}
