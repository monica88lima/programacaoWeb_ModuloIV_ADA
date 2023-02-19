using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEvent.Infra.Data.Repository
{
    public class CityEventRepository
    {
        private string _stringConnection { get; set; }
        public CityEventRepository()
        {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }
    }
}
