using ClassManager.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.ViewModels
{
    public partial class CadastroPageViewModel : ObservableObject
    {
        private string _username;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }

        public Command Cadastrar { get; set; }

        public CadastroPageViewModel(ISQLiteClientService clientService)
        {
            Cadastrar = new Command(async () =>
            {
                if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(ConfirmPassword))
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
                    return;
                }
                else if (Password != ConfirmPassword)
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "As senhas não coincidem.", "OK");
                    return;
                }
                var novoClient = new Models.Client
                {
                    Nome = Username,
                    Email = Email,
                    Senha = Password
                };
                try
                {
                    await clientService.AddClientAsync(novoClient);

                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Cadastro realizado com sucesso!", "OK");

                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", $"Ocorreu um erro ao cadastrar: {ex.Message}", "OK");
                }
            });
        }
    }
}
