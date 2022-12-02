using Source.Command;
using Source.Models;
using Source.Repositories.Concretes;
using Source.Repositories.Contexts;
using Source.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace Source.VeiwModels;

public class RegistrationUserStep3VeiwModel : BaseViewModel
{

    private readonly NavigationStore _navigationStore;


    private User User { get; set; } = new();


    public string? Username { get; set; } = string.Empty;
    public string? Password { get; set; } = string.Empty;
    public bool RememberMe { get; set; } = true;
    
    public ICommand PreviusCommand { get; set; }
    public ICommand EndCommand { get; set; }
    public ICommand SingInCommand { get; set; }
    
    public RegistrationUserStep3VeiwModel(NavigationStore navigationStore, User user)
    {
        _navigationStore = navigationStore;
        User = user;
        EndCommand = new RelayCommand(ExecuteEndCommand, CanExecuteEndCommand);
        SingInCommand = new RelayCommand(ExecutSingInCommand);
        PreviusCommand = new RelayCommand(ExecutPreviusCommand);
    }
    
    private void ExecutPreviusCommand(object? obj)
        => _navigationStore.CurrentViewModel = new RegistrationUserStep2VeiwModel(_navigationStore , User);

    private void ExecutSingInCommand(object? obj)
        => _navigationStore.CurrentViewModel = new SingInUserVeiwModel(_navigationStore);

    private bool CanExecuteEndCommand(object? obj)
        => Username?.Length > 0 &&
            Password?.Length > 6;
    private void ExecuteEndCommand(object? obj)
    {
        foreach (var item in FakeDbContext.Users)
        {
            if (item.Username == Username)
            {
                MessageBox.Show("There is a User in this name, you must change username");
                return;
            }
        }
        User.Username = Username;
        User.Password = Password;
        User.RememberMe = RememberMe;
        _navigationStore.CurrentViewModel = new HomeVeiwModel(_navigationStore , User);
    }
}
