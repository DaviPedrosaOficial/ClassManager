// SQLiteClientService.cs
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ClassManager.Services
{
    public class SQLiteClientService : ISQLiteClientService
    {
        private SQLiteAsyncConnection _dbConnection;
        private bool _initialized;

        public async Task InitializeAsync()
        {
            if (_initialized) 
                return;

            await SetUpDb();
            _initialized = true;
        }

        private async Task SetUpDb()
        {
            if (_dbConnection == null) 
            {
                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "classmanager.db3");

                _dbConnection = new SQLiteAsyncConnection(path);

                await _dbConnection.CreateTableAsync<Models.Client>();

                await _dbConnection.CreateTableAsync<Models.Instituicao>();
            }
        }

        public async Task<int> AddClientAsync(Models.Client client)
        {
            await InitializeAsync(); // garante que a conexão com o banco de dados exista
            return await _dbConnection.InsertAsync(client);
        }

        public async Task<List<Models.Client>> GetClientsAsync()
        {
            await InitializeAsync();
            return await _dbConnection.Table<Models.Client>().ToListAsync();
        }

        public async Task<int> AddInstituicaoAsync(Models.Instituicao instituicao, int clientId)
        {
            await InitializeAsync();
            instituicao.ClientId = clientId;
            return await _dbConnection.InsertAsync(instituicao);
        }

        public async Task<List<Models.Instituicao>> GetInstituicoesByClientIdAsync(int clientId)
        {
            await InitializeAsync();
            return await _dbConnection.Table<Models.Instituicao>()
                                       .Where(i => i.ClientId == clientId)
                                       .ToListAsync();
        }
    }
}
