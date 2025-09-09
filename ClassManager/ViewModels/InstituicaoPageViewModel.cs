using ClassManager.Models;
using ClassManager.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.ViewModels
{
    public partial class InstituicaoPageViewModel : ObservableObject
    {
        public Instituicao Instituicao_do_client { get; set; }
        public InstituicaoPageViewModel(ISQLiteClientService clientService, Instituicao instituicao_do_client)
        {
            Instituicao_do_client = instituicao_do_client;
        }
    }
}
