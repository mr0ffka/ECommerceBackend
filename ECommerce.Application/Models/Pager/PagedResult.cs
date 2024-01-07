using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.Pager
{
    public class PagedResult<T>
    {
        public int TotalRows { get; set; }
        public IEnumerable<T> Items { get; set; }

        #region Pagination()
        public PagedResult()
        {
            TotalRows = 0;
        }

        public PagedResult(IEnumerable<T> items, int totalRows) : this()
        {
            TotalRows = totalRows;
            Items = items;
        }
        #endregion
    }

}
