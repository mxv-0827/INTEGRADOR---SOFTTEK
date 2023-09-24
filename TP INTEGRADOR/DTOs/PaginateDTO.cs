namespace TP_INTEGRADOR.DTOs
{
    public class PaginateDTO<T>
    {
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string? PrevURL { get; set; }
        public string? NextURL { get; set; }
        public List<T> Items { get; set; }
    }
}
