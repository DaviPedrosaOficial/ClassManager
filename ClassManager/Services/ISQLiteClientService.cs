using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.Services
{
    public interface ISQLiteClientService
    {
        Task InitializeAsync();
        Task<int> AddClientAsync(Models.Client client);
        Task<List<Models.Client>> GetClientsAsync();
        Task<int> AddInstituicaoAsync(Models.Instituicao instituicao, int clientId);
        Task<List<Models.Instituicao>> GetInstituicoesByClientIdAsync(int clientId);
    }
}
