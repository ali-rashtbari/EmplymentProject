using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Common.Dtos
{
    public class GetListResultDto<T>
    {
        public IReadOnlyList<T> Values { get; set; }
        public GetListMetaData MetaValues { get; set; }
    }
}
