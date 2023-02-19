using System.ComponentModel.DataAnnotations;

namespace APIEventos.Entities
{
    public class EventReservationEntities
    {
        [Required]
        public long IdReservation { get; set; }



        [Required]
        //[DisplayColumn("IdEvent")]
        public long IdEvent { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome é obrigatório!")]
        public string PersonName { get; set; }



        [Required]
        public long Quantity { get; set; }


    }
}
