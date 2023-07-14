using Employment.Domain.BasesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class Category : DomainBaseEntity, IAuditable
    {
        public DateTime DateTimeAdded { get; set; }
        public DateTime? DateTimeModified { get; set; }
        public DateTime? DateTimeDeleted { get; set; }
        public string Name { get; set; }

        #region Relations 
        public virtual ICollection<Category> Childs { get; set; }
        public virtual Category Parent { get; set; }
        public int? ParentId { get; set; }
        #endregion Relations 
    }
}
