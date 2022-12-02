using Source.Command;
using Source.Models;
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

namespace Source.VeiwModels.Settings
{
    public class SettingUpdateUserVeiwModel :BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private User User { get; set; } = new();
        public string? Username { get; set; }
        public string? OldPassword { get; set; }
        public string? OldTestPassword { get; set; }
        public string? NewPassword { get; set; } = string.Empty;
        public string? Email { get; set; }//
        public bool RememberMe { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public DateTime BrithDay { get; set; }

        public ICommand SubmitCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public SettingUpdateUserVeiwModel(NavigationStore navigationStore, User user)
        {
            _navigationStore = navigationStore;
            User = user;
            Username = user.Username;
            OldTestPassword = user.Password;
            Email = user.Email;
            RememberMe = user.RememberMe;
            Surname = user.Surname;
            Name = user.Name;
            BrithDay = user.BrithDay;

            SubmitCommand = new RelayCommand(ExecutSubmitCommand , CanExecutSubmitCommand);
            CancelCommand = new RelayCommand(ExecutCancelCommand);
        }

        private bool CanExecutSubmitCommand(object? obj)
        {
                return Username?.Length > 0 &&
                    (Email.Contains("@gmail.com") || Email.Contains("@mail.ru"))
                    && Email.Length > 11
                    && Name?.Length > 3
                    && Surname?.Length > 3
                    && NewPassword?.Length > 6;
        }

        private void ExecutCancelCommand(object? obj)
                    => _navigationStore.CurrentViewModel = new SettingsVeiwModel(_navigationStore, User);

        private void ExecutSubmitCommand(object? obj)
        {
            foreach (var item in FakeDbContext.Users)
            {
                if (item.Username == Username)
                {
                    MessageBox.Show("There is a User in this name, you must change username");
                    return;
                }
            }
            if (OldPassword != OldTestPassword)
            {
                MessageBox.Show("Old Password Wrong");
                return;
            }

            User.Name = Name;
            User.Username = Username;
            User.Password = NewPassword;
            User.BrithDay = BrithDay;
            User.Email = Email;
            User.RememberMe = RememberMe;
            _navigationStore.CurrentViewModel = new SettingsVeiwModel(_navigationStore, User);
        }
    }
}
