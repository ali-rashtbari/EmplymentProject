using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.CommonDto
{
    public record GetDetailsRequestDto
    {
        public string EncodedID { get; init; }
        public int DecodedID { get; init; }
    }
}
