using ClassManager.Models;
using ClassManager.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {

        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public Command LoginCommand { get; set; }
        public Command CadastroCommand { get; set; }

        public LoginPageViewModel(ISQLiteClientService dbClient) 
        {
            _username = string.Empty;
            _password = string.Empty;

            LoginCommand = new Command(async () =>
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Login ou senha não preenchidos", "OK");
                        return;
                    }
                    else
                    {
                        List<Client> clients = await dbClient.GetClientsAsync();
                        var usuario = clients.FirstOrDefault(c => c.Email == Username && c.Senha == Password);
                        if (usuario != null)
                        {
                            await Application.Current.MainPage.DisplayAlert("Success", "Login realizado com sucesso!", "OK");
                            Application.Current.MainPage = new NavigationPage(new MainPage(dbClient, usuario));
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Error", "Login ou senha invalidos", "OK");
                        }
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            });

            CadastroCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Views.CadastroPage(dbClient));
            });
        }
    }
}
