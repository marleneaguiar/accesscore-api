using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Security
{
    public interface IPasswordHasher
    {
        string Hash(string password);
    }
}