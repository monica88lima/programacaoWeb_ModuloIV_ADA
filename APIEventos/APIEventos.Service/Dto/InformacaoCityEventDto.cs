using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEventos.Service.Dto
{
    public class InformacaoCityEventDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateHourEvent { get; set; }

        public string local { get; set; }

        public string Address { get; set; }

        public decimal Price { get; set; }


    }
}
