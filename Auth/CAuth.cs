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

        public CAuth()
        {

        }
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

            sr.Close();
            fs.Close();
            return list;
        }
        public void auth()
        {
            List<CAuth> UserData = loadPasswordFile("userdata.txt");

            foreach( CAuth user in UserData)
            {
                if (user.userName == this.userName && user.userPassword == cryptPassword(this.userPassword))
                {
                    Authed = true;
                }
            }
        }
        public string cryptPassword(string password)
        {
            byte xorConstant = 0x53;
            byte[] data = Encoding.UTF8.GetBytes(password);

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] ^ xorConstant);
            }

            string output = Convert.ToBase64String(data);

            return output;
        }

        private string encryptPassword(string password)
        {
            byte xorConstant = 0x53;
            byte[] data = Convert.FromBase64String(password);

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] ^ xorConstant);
            }

            string plain = Encoding.UTF8.GetString(data);

            return plain;
        }
        private void signIn()
        {

        }

        private void signOut()
        {

        }
    }
}
