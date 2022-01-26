using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Settings
{
    public class MongoDbSettings
    {
        public string ConnectionString;
        public string Database;
        public const string ConnectionStringValue = nameof(ConnectionString);
        public const string DatabaseValue = nameof(Database);
    }
}
