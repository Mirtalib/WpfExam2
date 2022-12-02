using Source.Command;
using Source.Models;
using Source.Repositories.Concretes;
using Source.Repositories.Contexts;
using Source.Stores;
using Source.VeiwModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Source.VeiwModels
{
    public class ProfileVeiwModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private User User { get; set; } = new();
        public string Username { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
        public ICommand SingOut { get; set; }
        public ICommand Previus { get; set; }
        public ICommand Setting { get; set; }


        public ProfileVeiwModel(NavigationStore navigationStore, User user)
        {
            _navigationStore = navigationStore;
            User = user;
            Username = user.Username;
            RememberMe = User.RememberMe;
            SingOut = new RelayCommand(ExecutSingOut);
            Previus = new RelayCommand(ExecutPrevius);
            Setting = new RelayCommand(ExecutSetting);
        }

        private void ExecutPrevius(object? obj)
        {
            User.RememberMe = RememberMe;
            _navigationStore.CurrentViewModel = new HomeVeiwModel(_navigationStore, User);
        }

        private void ExecutSetting(object? obj)
            => _navigationStore.CurrentViewModel = new SettingsVeiwModel(_navigationStore, User);

        private void ExecutSingOut(object? obj)
            =>_navigationStore.CurrentViewModel = new SingOutVeiwModel(_navigationStore, User);
    }
}
