using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapplication
{
    public class AppSettings
    {
        public DBConnectionClass DBConnections { get; set; }
        public FilesConnectionClass Files { get; set; }
        public class DBConnectionClass
        {
            public string defaultDbConnection { get; set; }
        }
        public class FilesConnectionClass
        {
            public string defaultFile { get; set; }
        }
    }
}
