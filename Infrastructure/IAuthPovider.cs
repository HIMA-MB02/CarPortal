using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VahanBlog.Infrastructure
{
    public interface IAuthPovider
    {
        bool Authenticate(string username, string password);
    }
}
