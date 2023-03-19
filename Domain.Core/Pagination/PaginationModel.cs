namespace Domain.Core.Pagination
{
    public class PaginationModel
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int totalRecords { get; set; }
        public object data { get; set; }
        public PaginationModel(int currentPage, int pageSize, int totalRecords, object data)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            this.totalRecords = totalRecords;
            this.data = data;
        }
    }
}
