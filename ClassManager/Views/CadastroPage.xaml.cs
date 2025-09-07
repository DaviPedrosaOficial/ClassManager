using ClassManager.Services;

namespace ClassManager.Views;

public partial class CadastroPage : ContentPage
{
	private readonly Services.ISQLiteClientService _clientService;
    public CadastroPage(ISQLiteClientService clientService)
	{
		_clientService = clientService;
		InitializeComponent();
        BindingContext = new ViewModels.CadastroPageViewModel(clientService);
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		// Garante que o DB esteja pronto antes de qualquer ação
		await _clientService.InitializeAsync();
    }
}