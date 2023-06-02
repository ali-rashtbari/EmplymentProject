using Employment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class Province : BaseNamesWithId<int>
    {


        #region Relations 

        public virtual Country Country { get; set; }
        public int CountryId { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        #endregion
    }
}
