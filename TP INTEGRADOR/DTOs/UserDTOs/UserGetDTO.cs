namespace TP_INTEGRADOR.DTOs.UserDTOs
{
    public class UserGetDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DNI { get; set; }
        public int UserRole { get; set; }
        public DateTime? LeavingDate { get; set; }
    }
}
