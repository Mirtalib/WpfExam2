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

public class RegistrationUserStep1VeiwModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    public User User { get; set; } = new(); 


    public string? Email { get; set; } = string.Empty;
    public ICommand CancelCommand { get; set; }
    public ICommand NextCommand { get; set; }
    public ICommand SingInCommand { get; set; }
    public RegistrationUserStep1VeiwModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;

        NextCommand = new RelayCommand(ExecuteNextCommand, CanExecuteNextCommand);
        SingInCommand = new RelayCommand(ExecutSingInCommand);
        CancelCommand = new RelayCommand(ExecuteCancelCommand);
    }

    private void ExecuteCancelCommand(object? obj)
        => _navigationStore.CurrentViewModel = new SingInUserVeiwModel(_navigationStore);

    private void ExecutSingInCommand(object? obj)
        => _navigationStore.CurrentViewModel = new SingInUserVeiwModel(_navigationStore);


    private bool CanExecuteNextCommand(object? obj)
        =>(Email.Contains("@gmail.com") || Email.Contains("@mail.ru"))
            && Email.Length > 11;
    

    private void ExecuteNextCommand(object? obj)
    {
        User.Id = Guid.NewGuid();
        User.Email = Email;
        _navigationStore.CurrentViewModel = new RegistrationUserStep2VeiwModel(_navigationStore , User);
    }
}
