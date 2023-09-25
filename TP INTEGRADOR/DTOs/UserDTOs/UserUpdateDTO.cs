namespace TP_INTEGRADOR.DTOs.UserDTOs
{
    public class UserUpdateDTO
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int UserRole { get; set; }
        public DateTime? LeavingDate { get; set; }
    }
}
