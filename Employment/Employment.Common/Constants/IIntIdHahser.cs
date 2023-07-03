using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Common.Constants
{
    public interface IIntIdHahser
    {
        string Code(int rawId);
        int DeCode(string hashId);
    }
}
