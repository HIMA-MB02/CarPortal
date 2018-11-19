using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using VahanBlog.Infrastructure;

namespace VahanBlog.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthPovider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
    }
}