using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    class User
    {
        private string name;
        private string password;
        public User( string name, string password)
        {
            this.name = name;
            this.password = password;
        }
        public void create()
        {
            FileStream fs = new FileStream("userdata.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            CAuth auth = new CAuth();
            sw.WriteLine(this.name + ";" + auth.cryptPassword(this.password));
            sw.Close();
            fs.Close();
        }
    }
}
