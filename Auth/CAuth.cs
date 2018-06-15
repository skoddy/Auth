using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    class CAuth
    {
        private string userName;
        private string userPassword;
        private bool authed;
        // public string UserName { get { return userName; } set { userName = value; } }
        // public string UserPassword { get { return userPassword; } set { userPassword = value; } }
        public bool Authed { get { return authed; } set { authed = value; } }
        public CAuth( string userName, string userPassword)
        {
            this.userName = userName;
            this.userPassword = userPassword;
            this.authed = false;
        }
        private List<CAuth> loadPasswordFile(string file)
        {
            List<CAuth> list = new List<CAuth>();
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() != -1)
            {
                string[] userData = sr.ReadLine().Split(';');
                list.Add(new CAuth(userData[0], userData[1]));
            }
            return list;
        }
        public void auth()
        {
            List<CAuth> UserData = loadPasswordFile("userdata.txt");
            foreach( CAuth user in UserData)
            {
                if (user.userName == this.userName && user.userPassword == this.userPassword)
                {
                    Authed = true;
                }
            }
        }

        private void signIn()
        {

        }

        private void signOut()
        {

        }
    }
}
