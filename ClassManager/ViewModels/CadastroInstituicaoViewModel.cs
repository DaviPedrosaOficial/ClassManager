using ClassManager.Models;
using ClassManager.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.ViewModels
{
    public partial class CadastroInstituicaoViewModel : ObservableObject
    {
        private readonly Client _clientLogado;

        public string _nomeInstituicao;
        public string NomeInstituicao 
        { get => _nomeInstituicao;
          set => SetProperty(ref _nomeInstituicao, value);
        }

        public Command CadastrarInstituicaoCommand { get; }


        public CadastroInstituicaoViewModel(ISQLiteClientService clientService, Client clientLogado)
        {

            _clientLogado = clientLogado;

            CadastrarInstituicaoCommand = new Command(async () =>
            {
                if (string.IsNullOrWhiteSpace(NomeInstituicao))
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "O nome da instituição não pode estar vazio.", "OK");
                    return;
                }
                var novaInstituicao = new Instituicao
                {
                    Nome = NomeInstituicao,
                    ClientId = _clientLogado.Id,
                    MediaNotas = 0,
                    MediaFrequencia = 0
                };
                try
                {
                    await clientService.AddInstituicaoAsync(novaInstituicao, _clientLogado.Id);
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Instituição cadastrada com sucesso!", "OK");

                    NomeInstituicao = string.Empty;
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", $"Falha ao cadastrar instituição: {ex.Message}", "OK");
                }
            });

        }
    }
}
