using ClassManager.Models;
using ClassManager.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ClassManager
{
    public partial class MainPage : ContentPage
    {
        private readonly ViewModels.MainPageViewModel _viewModel;

        public MainPage(ISQLiteClientService clientService, Client clientLogado)
        {
            InitializeComponent();
            _viewModel = new ViewModels.MainPageViewModel(clientService, clientLogado);
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.CarregarInstituicoesAsync();
        }
    }
}
