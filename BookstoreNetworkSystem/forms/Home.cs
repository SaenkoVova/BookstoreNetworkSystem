using BookstoreNetworkSystem.models;
using BookstoreNetworkSystem.userControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreNetworkSystem.forms
{
    public partial class Home : Form
    {
        User _user;
        public Home(User user)
        {
            _user = user;
            InitializeComponent();
            label1.Text = $"Ласкаво просимо {user.login}";
            var uch = new UC_Home(user);
            AddControlsToPanel(uch);
        }
        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            controlPanel.Controls.Clear();
            controlPanel.Controls.Add(c);

        }

        private void favouriteButton_Click(object sender, EventArgs e)
        {
            var uch = new UC_Home(_user);
            AddControlsToPanel(uch);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ucb = new UC_BookStore(_user);
            AddControlsToPanel(ucb);
        }
    }
}
