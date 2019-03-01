using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace webapplication.Models
{
    public class ValuesModel
    {

        public AppSettings config;
        private readonly AppSettings connections;

        public ValuesModel(IOptions<AppSettings> appsettings)
        {
            connections = appsettings.Value;
            config = appsettings.Value;
        }
    }
}
