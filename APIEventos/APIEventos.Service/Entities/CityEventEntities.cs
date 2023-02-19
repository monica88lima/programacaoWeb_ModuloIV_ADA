using System.ComponentModel.DataAnnotations;

namespace APIEventos.Service.Entities
{
    public class CityEventEntities
    {
        [Required]
        public long IdEvent { get; set; }


        [MaxLength(100, ErrorMessage = "Máximo de caracter permitido {1}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Titulo é obrigatório!")]
        public string Title { get; set; }


        [MaxLength(100, ErrorMessage = "Máximo de caracter permitido {1}")]
        public string Description { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Data é obrigatório!")]
        public DateTime DateHourEvent { get; set; } 


        [MaxLength(100, ErrorMessage = "Máximo de caracter permitido {1}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Local é obrigatório!")]
        public string local { get; set; }


        [MaxLength(100, ErrorMessage = "Máximo de caracter permitido {1}")]
        public string Address { get; set; }


        public decimal Price { get; set; }


        public bool Status { get; set; } 
    }
    //quando criar a DTO, pense no que vai apresentar no Swagguer, ou seja, para quem vai consumir a API
}
