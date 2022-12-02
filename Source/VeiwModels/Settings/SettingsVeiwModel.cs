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

namespace Source.VeiwModels.Settings
{
    public class SettingsVeiwModel:BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private User User { get; set; } = new();
        public ICommand DeleteUser { get; set; }
        public ICommand UpdateUser { get; set; }
        public ICommand SingOut { get; set; }
        public ICommand Previus { get; set; }


        public SettingsVeiwModel(NavigationStore navigationStore, User user)
        {
            _navigationStore = navigationStore;
            User = user;
            DeleteUser = new RelayCommand(ExecutDeleteUser);
            SingOut = new RelayCommand(ExecutSingOut);
            Previus = new RelayCommand(ExecutPrevius);
            UpdateUser = new RelayCommand(ExecutUpdateUser);
        }

        private void ExecutPrevius(object? obj)
            => _navigationStore.CurrentViewModel = new ProfileVeiwModel(_navigationStore, User);

        private void ExecutUpdateUser(object? obj)
            => _navigationStore.CurrentViewModel = new SettingUpdateUserVeiwModel(_navigationStore, User);

        private void ExecutSingOut(object? obj)
            => _navigationStore.CurrentViewModel = new SingOutVeiwModel(_navigationStore, User);

        private void ExecutDeleteUser(object? obj)
        {
            FakeDbContext.WriteUsers();
            _navigationStore.CurrentViewModel = new SingInUserVeiwModel(_navigationStore);
        }
    }
}
