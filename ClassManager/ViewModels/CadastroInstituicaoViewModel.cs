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
    public partial class CadastroInstituicaoViewModel : ObservableObject
    {

        public CadastroInstituicaoViewModel(ISQLiteClientService clientService, Client clientLogado)
        {
        }
    }
}
