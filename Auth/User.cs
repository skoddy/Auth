using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream("userdata.txt", FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs);
                CAuth auth = new CAuth();
                sw.WriteLine(this.name + ";" + auth.cryptPassword(this.password));
                MessageBox.Show("Benutzer angelegt, Sie können sich jetzt anmelden", "Erfolg", MessageBoxButtons.OK);

            }
            catch(FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK);
            }
            finally
            {
                if(sw != null)
                {
                    sw.Close();
                }
                if(fs != null)
                {
                    fs.Close();
                }
            }
        }
    }
}
