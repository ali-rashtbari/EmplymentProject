using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.CommonDto
{
    public abstract class UpdateEntitiesBaseDto
    {
        public string EncodedID { get; init; }
        [JsonIgnore]
        public int DecodedID { get; init; }
    }
}
