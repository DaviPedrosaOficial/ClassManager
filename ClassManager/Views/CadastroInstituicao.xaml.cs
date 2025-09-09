using ClassManager.Models;
using ClassManager.Services;

namespace ClassManager.Views;

public partial class CadastroInstituicao : ContentPage
{
	private readonly ISQLiteClientService _clientService;
    public CadastroInstituicao(ISQLiteClientService clientService, Client clientLogado)
	{
        _clientService = clientService;
        InitializeComponent();
		BindingContext = new ViewModels.CadastroInstituicaoViewModel(_clientService, clientLogado);
    }

	protected override async void OnAppearing() 
	{
		base.OnAppearing();
		// Garante que o DB esteja pronto antes de qualquer ação
		await _clientService.InitializeAsync();
    }
}