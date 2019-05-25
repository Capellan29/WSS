using System;
using System.Collections.Generic;
using System.Text;

namespace WSS.Domain.Core.Paging
{
    public class PagingResult<T>
    {
        public PagingHeader Pagination { get; set; }
        public List<T> Items { get; set; }
    }
}
