using ClassManager.Services;

namespace ClassManager
{
    public partial class MainPage : ContentPage
    {
        private readonly ISQLiteClientService _clientService;

        public MainPage(ISQLiteClientService clientService)
        {
            _clientService = clientService;
            InitializeComponent();
            BindingContext = new ViewModels.MainPageViewModel(_clientService);
        }
    }
}
