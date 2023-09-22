namespace TP_INTEGRADOR.DTOs.ServiceDTOs
{
    public class ServiceGetDTO
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public decimal HourValue { get; set; }
        public DateTime? LeavingDate { get; set; }
    }
}
