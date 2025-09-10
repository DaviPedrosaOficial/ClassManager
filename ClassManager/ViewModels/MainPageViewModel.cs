using ClassManager.Models;
using ClassManager.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        public readonly ISQLiteClientService _clientService;

        private readonly Client _clientLogado;
        public Client ClientLogado => _clientLogado;

        [ObservableProperty]
        private ObservableCollection<Instituicao> instituicoes;

        public Command RedirecionarPaginaAddInstituicao { get; }
        public Command DeslogarUsuario { get; }
        public Command<Instituicao> ItemSelecionadoCommand { get; }

        public MainPageViewModel(ISQLiteClientService clientService, Client clientLogado)
        {
            _clientService = clientService;
            _clientLogado = clientLogado;
            Instituicoes = new ObservableCollection<Instituicao>();

            RedirecionarPaginaAddInstituicao = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new Views.CadastroInstituicao(clientService, clientLogado));
            });

            DeslogarUsuario = new Command(async () =>
            {
                bool confirmar = await App.Current.MainPage.DisplayAlert("Confirmação", "Deseja realmente deslogar?", "Sim", "Não");
                if (confirmar)
                {
                    Preferences.Remove("_clientLogado");
                    App.Current.MainPage = new Views.LoginPage(clientService);
                }
            });

            ItemSelecionadoCommand = new Command<Instituicao>(async (instituicaoSelecionada) =>
            {
                if (instituicaoSelecionada != null)
                {
                    await App.Current.MainPage.Navigation.PushAsync(
                        new Views.InstituicaoPage(_clientService, instituicaoSelecionada)
                    );
                }
            });

            Task.Run(async () => await CarregarInstituicoesAsync());
        }

        public async Task CarregarInstituicoesAsync()
        {
            await _clientService.InitializeAsync();
            var lista = await _clientService.GetInstituicoesByClientIdAsync(_clientLogado.Id);

            Instituicoes.Clear();
            foreach (var inst in lista)
                Instituicoes.Add(inst);
        }

    }
}
