using E_Commerce.Service.Helpers;

namespace E_Commerce.Core.Helpers
{
    public class PaginationResultWithInfoAndData<T>
    {
        public PaginationResultWithInfoAndData(RequestParameters requestParameters,int count,IReadOnlyList<T> data)
        {
            PageNumber = requestParameters.PageNumber;
            PageSize = requestParameters.PageSize;
            Count = count;
            Data = data;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
