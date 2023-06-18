using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_1._0.Res.PagesAndWindows
{
    public class User
    {
        public string Username { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User(string username,  string password, string login)
        {
            Username = username;
            Password = password;
            Login = login;
        }
    }
}
