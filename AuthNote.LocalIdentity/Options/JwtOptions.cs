using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthNote.LocalIdentity.Options
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public int ExpiredHours { get; set; }
    }
}
