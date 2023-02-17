using System.ComponentModel.DataAnnotations;

namespace Aula2_API
{
    public class Cliente
    {
        public int ID_Cliente { get; set; }

        [Required(ErrorMessage = "Nome Obrigatório")]
        [StringLength(25, ErrorMessage = "O nome não e muito grande, não ultrapasse {1} caracteres")]
        
        public string? Nome { get; set; }
        //o ? deixa o Required - se tirar o ? tem que colocar assim (Required(AllowEmptyStrings = false)], pq ai informo que não aceito vazio.
        
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatoria.")]
        [Range(5,10, ErrorMessage ="Quantidade deve ser minimo de {1} e maximo de {2}.")]
        public int QuantidadePorPedido { get; set; }
         
        public int Idade => DateTime.Now.AddYears(-DataNascimento.Year).Year;
    }
}
