using ClassManager.Models;
using ClassManager.Services;
using System.Threading.Tasks;

namespace ClassManager.Views;

public partial class InstituicaoPage : ContentPage
{
	private readonly ISQLiteClientService _clientService;

	private readonly Instituicao _instituicao_do_client;

    public InstituicaoPage(ISQLiteClientService clientService, Instituicao instituicao_do_client)
	{
        _clientService = clientService;
        _instituicao_do_client = instituicao_do_client;
        InitializeComponent();
        BindingContext = new ViewModels.InstituicaoPageViewModel(_clientService, _instituicao_do_client);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _clientService.InitializeAsync();
    }
}