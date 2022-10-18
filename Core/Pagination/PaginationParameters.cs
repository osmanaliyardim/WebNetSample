namespace WebNetSample.Core.Pagination;

public abstract class PaginationParameters
{
    const int maxPageSize = 48;

    public int PageNumber { get; set; } = 1;

    private int _pageSize = 12;

    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}
