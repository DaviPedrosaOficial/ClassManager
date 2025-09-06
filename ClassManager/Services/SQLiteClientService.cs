using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.Services
{
    public class SQLiteClientService
    {
        private SQLiteAsyncConnection _dbConnection;
        
        public async Task InitializeAsync(string dbPath)
        {
            await SetUpDb();
        }

        public async Task SetUpDb()
        {
            if (_dbConnection != null)
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "classmanager.db3");

                _dbConnection = new SQLiteAsyncConnection(path);
                await _dbConnection.CreateTableAsync<Models.Client>();
            }
        }

        public async Task<int> AddClientAsync(Models.Client client)
        {
            return await _dbConnection.InsertAsync(client);
        }


    }
}
