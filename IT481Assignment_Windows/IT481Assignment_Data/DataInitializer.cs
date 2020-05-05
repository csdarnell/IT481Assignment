using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace IT481Assignment_Data
{
    public class DataInitializer
    {
        private readonly string connectionString;

        private DataManager dataManager;

        public DataInitializer(string connectionString)
        {
            this.connectionString = connectionString;
            dataManager = new DataManager(connectionString);
        }

        public DataManager GetDataManager()
        {
            return dataManager;
        }
    }
}
