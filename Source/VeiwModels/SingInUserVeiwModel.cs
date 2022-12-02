using Source.Command;
using Source.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Newtonsoft.Json;
using Source.Models;
using System.IO;
using System.Windows.Controls;
using Source.Repositories.Concretes;
using Source.Repositories.Contexts;

namespace Source.VeiwModels;

public class SingInUserVeiwModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool RememberMe { get; set; } = false;
    public ICommand SingInCommand { get; set; }
    public ICommand SingUpCommand { get; set; }
    public ICommand CheckingRememberMe { get; set; }



    public SingInUserVeiwModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        CheckingRememberMe = new RelayCommand(ExecuteCheckingRememberMe);
        SingInCommand = new RelayCommand(ExecuteSingInCommand, CanExecuteSingInCommand);
        SingUpCommand = new RelayCommand(ExecuteSingUpCommand);
    }


    private void ExecuteCheckingRememberMe(object? obj)
    {
        // MouseDoubleClick
        FakeDbContext.GetUsers();
        if (FakeDbContext.Users is not null)
        {
            foreach (var user in FakeDbContext.Users)
            {
                if(user.RememberMe == true)
                {
                    FakeUserRepository fakeUserRepository = new FakeUserRepository();
                    fakeUserRepository.Remove(user);
                    if (user.Movies == null)
                        user.Movies = new();
                    _navigationStore.CurrentViewModel = new HomeVeiwModel(_navigationStore,user);
                    return;
                }
            } 
        }
    }

    private bool CanExecuteSingInCommand(object? obj)
    {
        return !string.IsNullOrWhiteSpace(Username) 
            && !string.IsNullOrWhiteSpace(Password);
    }

    void ExecuteSingUpCommand(object? parameter)
        =>_navigationStore.CurrentViewModel = new RegistrationUserStep1VeiwModel(_navigationStore);



    void ExecuteSingInCommand(object? parameter)
    {        
        FakeDbContext.GetUsers();
        if (FakeDbContext.Users is null)
            return;
        foreach (var user in FakeDbContext.Users)
        {
            if(user?.Username == Username)
            {
                if (user?.Password == Password)
                {

                    FakeUserRepository fakeUserRepository = new FakeUserRepository();
                    fakeUserRepository.Remove(user);
                    foreach (var item in FakeDbContext.Users)
                        item.RememberMe = false;
                    if (user.Movies == null)
                        user.Movies = new();
                    user.RememberMe = RememberMe;
                    _navigationStore.CurrentViewModel = new HomeVeiwModel(_navigationStore, user);
                    return;
                }
                else
                {
                    MessageBox.Show("Password Wrong");
                    return;
                }
            }
        }
        MessageBox.Show("Username Wrong");
    }

}
