using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetStudy
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }


        public void btnLogin_Click_1(object sender, EventArgs e)
        {

        }    
        public void linkClear_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();    
        }
    }
}
