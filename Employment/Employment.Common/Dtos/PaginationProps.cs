using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Common.Dtos
{
    public abstract class PaginationProps
    {
        private string? _search { get; set; }
        private int _pageNumber { get; set; }
        private int _pageSize { get; set; }
        private string? _orderBy { get; set; }
        private string? _orderDirection { get; set; }


        public string? Search
        {
            get
            {
                return _search;
                //return _search == null ? null : _search.ToLower();
                //if (string.IsNullOrWhiteSpace(_search))
                //{
                //    return null;
                //}
                //else
                //{
                //    return _search.ToLower();
                //}
            }
            set
            {
                _search = !String.IsNullOrWhiteSpace(value) ? value : null;
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
                _pageNumber = value > 0 ? value : 1;
                //if (value > 0) { _pageNumber = value; } else { _pageNumber = 1; }
            }
        }
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value > 0 ? value : 10;
                //if (value > 0) { _pageSize = value; } else { _pageSize = 10; }
            }
        }
        public string? OrderBy
        {
            get
            {
                return _orderBy ?? "id";
                //return !string.IsNullOrWhiteSpace(_orderBy) ? _orderBy : "id";
                //if (string.IsNullOrWhiteSpace(_orderBy))
                //{
                //    return "id";
                //}
                //else
                //{
                //    return _orderBy;
                //}
            }
            set
            {
                _orderBy = !string.IsNullOrWhiteSpace(value) ? value : "id";
            }
        }
        public string? OrderDirection
        {
            get
            {
                return _orderDirection ?? "asc";
                //return !string.IsNullOrWhiteSpace(_orderDirection) ? _orderDirection : "asc";
                //if (string.IsNullOrWhiteSpace(_orderDirection))
                //{
                //    return "asc";
                //}
                //else
                //{
                //    return _orderDirection;
                //}
            }
            set
            {
                _orderDirection = !string.IsNullOrWhiteSpace(value) ? value : "asc";
            }
        }
    }
}
