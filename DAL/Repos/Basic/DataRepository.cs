using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Basic
{
    public class DataRepository:IDataRepository
    {
        private readonly IConfiguration _config;
        public DataRepository(IConfiguration configuration)
        {
            _config = configuration;
        }
        public string GetConnection()
        {
            string c = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appSettings.json").Build();
            string connectionStringIs = configuration.GetConnectionString("conn");
            return connectionStringIs;
        }
    }
}
