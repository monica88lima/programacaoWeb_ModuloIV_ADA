using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEventos.Service.Dto
{
    public class InformacaoEventReservationDto
    {

        public int idReservation { get; set; }
        public string personName { get; set; }
        public int idEvent { get; set; }
        public int quntity { get; set; }
        public string title { get; set; }
    }
}
