namespace TP_INTEGRADOR.DTOs.WorkDTOs
{
    public class WorkGetDTO
    {
        public int ID { get; set; }
        public int CodProject { get; set; }
        public int CodService { get; set; }
        public int AmountHours { get; set; }
        public decimal ValuePerHour { get; set; }
        public decimal Cost { get; set; }
        public DateTime? LeavingDate { get; set; }
    }
}
