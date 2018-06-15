using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auth
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            CAuth user = new CAuth(userName.Text, userPassword.Text);
            user.auth();
            if (user.Authed)
            {
                Main main = new Main();
                main.Show();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void createUser_Click(object sender, EventArgs e)
        {
            User user = new User(userName.Text, userPassword.Text);
            user.create();
        }
    }
}
