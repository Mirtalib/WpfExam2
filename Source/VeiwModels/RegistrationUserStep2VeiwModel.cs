using Source.Command;
using Source.Models;
using Source.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Source.VeiwModels;

public class RegistrationUserStep2VeiwModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;


    private User User { get; set; } = new();


    public string? Name { get; set; } = string.Empty;
    public string? Surname { get; set; } = string.Empty;
    public DateTime DateTime { get; set; } = new DateTime(1930,1,1);
    public ICommand PreviusCommand { get; set; }
    public ICommand NextCommand { get; set; }
    public ICommand SingInCommand { get; set; }
    public RegistrationUserStep2VeiwModel(NavigationStore navigationStore, User user)
    {
        _navigationStore = navigationStore;
        User = user;
        NextCommand = new RelayCommand(ExecuteNextCommand, CanExecuteNextCommand);
        SingInCommand = new RelayCommand(ExecutSingInCommand);
        PreviusCommand = new RelayCommand(ExecutPreviusCommand);
    }

    private void ExecutPreviusCommand(object? obj)
        => _navigationStore.CurrentViewModel = new RegistrationUserStep1VeiwModel(_navigationStore);


    private void ExecutSingInCommand(object? obj)
        => _navigationStore.CurrentViewModel = new SingInUserVeiwModel(_navigationStore);

    private void ExecuteNextCommand(object? obj)
    {
        User.Name = Name;
        User.Surname = Surname;
        User.BrithDay = DateTime;
        _navigationStore.CurrentViewModel = new RegistrationUserStep3VeiwModel(_navigationStore, User);
    }

    private bool CanExecuteNextCommand(object? obj)
        => Name?.Length > 3 &&
            Surname?.Length > 3;
}
