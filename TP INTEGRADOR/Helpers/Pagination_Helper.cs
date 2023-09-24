using TP_INTEGRADOR.DTOs;

namespace TP_INTEGRADOR.Helpers
{
    public static class Pagination_Helper
    {
        public static PaginateDTO<T> Paginate<T>(List<T> itemsToPaginate, int? itemsPerPage, int currentPage, string url)
        {
            int pageSize = (int)(itemsPerPage == null ? itemsToPaginate.Count : itemsPerPage); //Si no recibe parametro, no se divide la lista. Seria una pagina con todos los items.
            int totalItems = itemsToPaginate.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var paginateItems = itemsToPaginate.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            var prevUrl = currentPage > 1 ? $"{url}?itemsPerPage={itemsPerPage}&page={currentPage - 1}" : null;
            var nextUrl = currentPage < totalPages ? $"{url}?itemsPerPage={itemsPerPage}&page={currentPage + 1}" : null;

            return new PaginateDTO<T>
            {
                TotalPages = totalPages,
                TotalItems = totalItems,
                CurrentPage = currentPage,
                PageSize = pageSize,
                PrevURL = prevUrl,
                NextURL = nextUrl,
                Items = paginateItems
            };
        }
    }
}
