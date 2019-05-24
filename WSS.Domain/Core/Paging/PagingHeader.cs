using System;
using System.Collections.Generic;
using System.Text;

namespace WSS.Domain.Core.Paging
{
    public class PagingHeader
    {
        public PagingHeader(int totalItems, int pageNumber, int pageSize, int totalPages, bool hasNextPage)
        {
            this.TotalItems = totalItems;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalPages = totalPages;
            this.HasNextPage = hasNextPage;
        }

        public int TotalItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public bool HasNextPage { get; }

    }
}
