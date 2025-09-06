using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.Services
{
    public class MongoDbService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MongoDbService> _logger;
        private readonly IMongoDatabase _database;

        public MongoDbService(IConfiguration configuration, ILogger<MongoDbService> logger) 
        {
            _configuration = configuration;

            _logger = logger;

            var c
        }
    }
}
