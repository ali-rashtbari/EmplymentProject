using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Common.Dtos
{
    public class PagedList<T> : List<T>
    {
        public GetListMetaData MetaData { get; private set; } = new GetListMetaData();

        public PagedList(List<T> dataList, int pageSize, int pageNumber, int totalCount, string? search)
        {
            MetaData.PageNumber = pageNumber;
            MetaData.TotalCount = totalCount;
            MetaData.PageSize = pageSize;
            MetaData.RowsCount = dataList.Count();
            MetaData.PagesCount = (int)Math.Ceiling(totalCount / (double)pageSize);
            MetaData.Search = search;
            AddRange(dataList);
        }

        /// <summary>
        /// create paginated list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public static PagedList<T> Create<T>(IQueryable<T> source, int pageSize, int pageNumber, string? search)
        {
            var result = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(result, pageSize, pageNumber, source.Count(), search);
        }
    }
}
