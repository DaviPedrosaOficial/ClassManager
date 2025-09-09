using ClassManager.Models;
using ClassManager.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ClassManager
{
    public partial class MainPage : ContentPage
    {
        private readonly ISQLiteClientService _clientService;

        public ObservableCollection<Instituicao> _instituicoes_do_cliente;

        public Client _clientLogado;

        public MainPage(ISQLiteClientService clientService,Client clientLogado)
        {
            _clientService = clientService;
            _clientLogado = clientLogado;
            InitializeComponent();
            BindingContext = new ViewModels.MainPageViewModel(_clientService, clientLogado);
        }

        protected override async void OnAppearing()
        {
            try 
            {

                base.OnAppearing();
                // Garante que o DB esteja pronto antes de qualquer ação
                await _clientService.InitializeAsync();

                var instituicoesList = await _clientService.GetInstituicoesByClientIdAsync(_clientLogado.Id);
                _instituicoes_do_cliente = new ObservableCollection<Instituicao>(instituicoesList);
                cv_instituicoes.ItemsSource = _instituicoes_do_cliente;

            }
            catch (Exception ex) 
            {
                await DisplayAlert("Erro!", "Erro apresentado: " + ex.Message, "Ok");
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
