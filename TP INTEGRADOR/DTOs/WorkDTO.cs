namespace TP_INTEGRADOR.DTOs
{
    public class WorkDTO
    {
        public int CodWork { get; set; }
        public DateTime Date { get; set; }
        public int CodProject { get; set; }
        public int CodService { get; set; }
        public int AmountHours { get; set; }
        public decimal ValuePerHour { get; set; }
        public decimal Cost { get; set; }
    }
}
