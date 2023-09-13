namespace TP_INTEGRADOR.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public int DNI { get; set; }
        public int UserRole { get; set; }
        public string Password { get; set; }
        public DateTime? LeavingDate { get; set; }
    }
}
