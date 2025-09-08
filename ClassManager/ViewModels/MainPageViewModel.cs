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
    public partial class MainPageViewModel : ObservableObject
    {
        public Command RedirecionarPaginaAddInstituicao { get; }
        public Command DeslogarUsuario { get; }

        public MainPageViewModel(ISQLiteClientService clientService, Client clientLogado)
        {
            RedirecionarPaginaAddInstituicao = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new Views.CadastroInstituicao(clientService, clientLogado));
            });

            DeslogarUsuario = new Command(async () =>
            {
                bool confirmar = await App.Current.MainPage.DisplayAlert("Confirmação", "Deseja realmente deslogar?", "Sim", "Não");
                if (confirmar)
                {
                    // Navega de volta para a página de login
                    App.Current.MainPage = new Views.LoginPage(clientService);
                }
            }); 
        }
    }
}
