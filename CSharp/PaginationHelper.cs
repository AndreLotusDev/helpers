public static class PaginationHelper
{
    public static async Task<(IQueryable<T> queryPaginated, int totalFound, int totalFoundAfterPagination, int totalPages)> PaginateAsync<T>(this IQueryable<T> toPaginate, int pageSize, int pageNumber)
    {
        var cutPagination = toPaginate
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize);

        var totalFound = await Task.Run(() => toPaginate.Count());
        var totalFoundAfterPagination = await Task.Run(() => cutPagination.Count());

        var totalPages = (int)Math.Ceiling((double)totalFound / pageSize);
        return new(cutPagination, totalFound, totalFoundAfterPagination, totalPages);
    }

    public static int CalculateTheTotalPages(int quantityOfItemsFound, int pageSize)
    {
        int totalPages = 0;
        try
        {
            totalPages = quantityOfItemsFound / pageSize;
            return totalPages;
        }
        catch (Exception)
        {
            totalPages = 0;
            return totalPages;
        }
    }
}
