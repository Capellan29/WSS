using System;
using System.Collections.Generic;
using System.Text;

namespace WSS.Domain.Core.Paging
{
    public class PagingParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 8;
        public string sortDirection { get; set; } = "desc";
        public string sortKey { get; set; }
        public string search { get; set; }
    }
}
