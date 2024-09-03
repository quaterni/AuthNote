using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthNote.LocalIdentity.Services.Abstractions
{
    public interface IHashService
    {
        string HashPassword(string password);

        bool VerifyPassword(string password, Identity identity);
    }
}
