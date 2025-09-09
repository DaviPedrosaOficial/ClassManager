using ClassManager.Models;
using ClassManager.Services;

namespace ClassManager
{
    public partial class MainPage : ContentPage
    {
        private readonly ISQLiteClientService _clientService;

        public MainPage(ISQLiteClientService clientService,Client clientLogado)
        {
            _clientService = clientService;
            InitializeComponent();
            BindingContext = new ViewModels.MainPageViewModel(_clientService, clientLogado);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Garante que o DB esteja pronto antes de qualquer ação
            await _clientService.InitializeAsync();
        }
    }
}
