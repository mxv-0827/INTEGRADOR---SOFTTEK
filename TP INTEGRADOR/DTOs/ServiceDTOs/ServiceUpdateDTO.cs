namespace TP_INTEGRADOR.DTOs.ServiceDTOs
{
    public class ServiceUpdateDTO
    {
        public string Description { get; set; }
        public bool State { get; set; }
        public decimal HourValue { get; set; }
        public DateTime? LeavingDate { get; set; }
    }
}
