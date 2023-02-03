namespace Aula2_API
{
    public class Cliente
    {
        public int ID_Cliente { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public int Idade => DateTime.Now.AddYears(-DataNascimento.Year).Year;
    }
}
