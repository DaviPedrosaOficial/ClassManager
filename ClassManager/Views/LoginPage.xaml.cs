// LoginPage.xaml.cs
using ClassManager.Services;

namespace ClassManager.Views;

public partial class LoginPage : ContentPage
{
    private readonly ISQLiteClientService _clientService;

    public LoginPage(ISQLiteClientService clientService)
    {
        _clientService = clientService;
        InitializeComponent();
        BindingContext = new ViewModels.LoginPageViewModel(clientService);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Garante que o DB esteja pronto antes de qualquer ação
        await _clientService.InitializeAsync();
    }
}
