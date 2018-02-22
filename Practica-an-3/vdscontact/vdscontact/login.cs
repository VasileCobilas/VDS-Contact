using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vdscontact
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            Vdscontact f1 = new Vdscontact();
            f1.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            registration f2 = new registration();
            f2.Show();
        }
    }
}
