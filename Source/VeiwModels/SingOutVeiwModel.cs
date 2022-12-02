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
using System.Windows.Input;

namespace Source.VeiwModels
{
    public class SingOutVeiwModel :BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private User User { get; set; } = new();
        public ICommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }

        public SingOutVeiwModel(NavigationStore navigationStore, User user)
        {
            _navigationStore = navigationStore;
            User = user;
            YesCommand = new RelayCommand(ExecuteYes);
            NoCommand = new RelayCommand(ExecuteNo);
        }

        private void ExecuteNo(object? obj)
        {
            User.RememberMe = false;
            FakeUserRepository fakeUserRepository = new();
            fakeUserRepository.Add(User);
            FakeDbContext.WriteUsers();
            App.Current.Shutdown();
        }

        private void ExecuteYes(object? obj)
        {
            User.RememberMe = true;
            FakeUserRepository fakeUserRepository = new();
            fakeUserRepository.Add(User);
            FakeDbContext.WriteUsers();
            App.Current.Shutdown();
        }
    }
}
