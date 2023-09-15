namespace TP_INTEGRADOR.DTOs
{
    public class LoginDTO
    {
        //El ID y el userRole ya estan dentro del token.
        public string UserName { get; set; }
        public int UserDNI { get; set; }
        public string UserToken { get; set; }
    }
}
