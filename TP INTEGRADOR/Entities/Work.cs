namespace TP_INTEGRADOR.Entities
{
    public class Work
    {
        public int CodWork { get; set; }
        public DateTime Date { get; set; }
        public int CodProject { get; set; }
        public int CodService { get; set; }
        public int AmountHours { get; set; }
        public decimal ValueHours { get; set; }
        public decimal Cost { get; set; }
    }
}
