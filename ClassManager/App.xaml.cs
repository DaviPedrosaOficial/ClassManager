using ClassManager.Services;

namespace ClassManager
{
    public partial class App : Application
    {
        public App(ISQLiteClientService clientService)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.LoginPage(clientService));
        }
    }
}