using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace l001
{
    public partial class Read : Form
    {
        string ID;
        public Read(string id, string login, string password, string name, string roled)
        {
            InitializeComponent();
            ID = id;
            txtLogin.Text = login;
            txtPassword.Text = password;
            txtName.Text = name;
            txtRoled.Text = roled;
        }
      
        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Hide();
           Users info = new Users();
            info.Visible = true;
            info.ShowInTaskbar = true;
        }
    }
}
