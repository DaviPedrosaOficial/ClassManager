using ClassManager.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel(ISQLiteClientService clientService)
        {
        }
    }
}
