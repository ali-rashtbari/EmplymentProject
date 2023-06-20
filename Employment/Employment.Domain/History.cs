using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class History
    {
        public string Id { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public string RecordId { get; set; }
        public string PreviousValue { get; set; }
        public string NextValue { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangeState { get; set; }
    }
}
