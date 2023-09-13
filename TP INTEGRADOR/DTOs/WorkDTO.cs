namespace TP_INTEGRADOR.DTOs
{
    public class WorkDTO
    {
        public DateTime Date { get; set; }
        public int CodProject { get; set; }
        public int CodService { get; set; }
        public int AmountHours { get; set; }
        public decimal ValuePerHour { get; set; }
        public DateTime? LeavingDate { get; set; }
    }
}
