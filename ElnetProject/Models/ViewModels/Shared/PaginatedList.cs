using Microsoft.EntityFrameworkCore;

namespace ElnetProject.Models.ViewModels.Shared
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; private set; }
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalItems { get; private set; }
        public int PageSize { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalItems = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items = items;
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public int FirstItemIndex => (PageIndex - 1) * PageSize + 1;
        public int LastItemIndex => Math.Min(PageIndex * PageSize, TotalItems);

        public static async Task<PaginatedList<T>> CreateAsync(
            IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip(
                (pageIndex - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

        // Helper method to generate page numbers for view
        public IEnumerable<int> GetVisiblePages(int maxPages = 5)
        {
            int startPage = Math.Max(1, PageIndex - (maxPages / 2));
            int endPage = Math.Min(TotalPages, startPage + maxPages - 1);

            if (endPage - startPage + 1 < maxPages)
            {
                startPage = Math.Max(1, endPage - maxPages + 1);
            }

            return Enumerable.Range(startPage, endPage - startPage + 1);
        }
    }
}