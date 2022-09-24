using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techo.Models.DataTransferObjects
{
    public class PagingDTO
    {
        const int maxPageSize = 50;
        private int _pageSize = 10;
        private int _pageNumber = 1;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : (value <= 0) ? _pageSize : value;
            }
        }
        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = value == 0 ? 1 : value;
            }
        }
        public string SearchParameter { get; set; }
    }
}
