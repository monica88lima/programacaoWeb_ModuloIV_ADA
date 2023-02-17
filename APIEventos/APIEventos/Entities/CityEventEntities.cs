namespace APIEventos.Entities
{
    public class CityEventEntities
    {
        public long IdEvent { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateHoursEvent { get; set; }

        public string Local { get; set; }

        public string Address { get; set; }

        public decimal Price { get; set; }

        public bool Status { get; set; }
    }
}
