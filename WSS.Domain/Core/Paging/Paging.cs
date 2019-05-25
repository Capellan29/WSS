using System;
using System.Collections.Generic;
using System.Text;

namespace WSS.Domain.Core.Paging
{
    public class Paging<T>
    {
        public Paging(List<T> items, int totalItems, PagingParams pagingParams)
        {
            this.TotalItems = totalItems;
            this.List = items;
            this.PageNumber = pagingParams.PageNumber;
            this.PageSize = pagingParams.PageSize;
        }

        public int TotalItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public List<T> List { get; }
        public int TotalPages => (int)Math.Ceiling(this.TotalItems / (double)this.PageSize);
        public bool HasPreviousPage => this.PageNumber > 1;
        public bool HasNextPage => this.PageNumber < this.TotalPages;
        public int NextPageNumber => this.HasNextPage ? this.PageNumber + 1 : this.TotalPages;
        public int PreviousPageNumber => this.HasPreviousPage ? this.PageNumber - 1 : 1;

        public PagingHeader GetHeader()
        {
            return new PagingHeader(this.TotalItems, this.PageNumber, this.PageSize, this.TotalPages, this.HasNextPage);
        }
    }
}
