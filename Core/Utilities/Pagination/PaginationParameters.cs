namespace WebNetSample.Core.Pagination;

public abstract class PaginationParameters
{
    const int maxPageSize = 48;

    private int _pageSize = 12;

    private int _recordsToSkip = 1;

    public int PageNumber { get; set; } = 1;

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

    public int RecordsToSkip
    {
        get
        {
            return _recordsToSkip = (PageNumber - 1) * PageSize;
        }
    }
}