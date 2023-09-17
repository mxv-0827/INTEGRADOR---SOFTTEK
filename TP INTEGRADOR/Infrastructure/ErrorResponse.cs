namespace TP_INTEGRADOR.Infrastructure
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public List<Error> Errors { get; set; }


        public class Error
        {
            public string Description { get; set; }
        }
    }
}
