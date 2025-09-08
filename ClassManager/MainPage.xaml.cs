using ClassManager.Models;
using ClassManager.Services;

namespace ClassManager
{
    public partial class MainPage : ContentPage
    {
        private readonly ISQLiteClientService _clientService;
        private readonly Client _clientLogado;

        public MainPage(ISQLiteClientService clientService,Client clientLogado)
        {
            _clientLogado = _clientLogado;
            _clientService = clientService;
            InitializeComponent();
            BindingContext = new ViewModels.MainPageViewModel(_clientService, _clientLogado);
        }
    }
}
