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
    public partial class AdminPanel : Form
    {
        public AdminPanel(models.User user)
        {
            InitializeComponent();
        }

        private void booksButton_Click(object sender, EventArgs e)
        {
            var ucab = new UC_AdminBooks();
            AddControlsToPanel(ucab);
        }
        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            controlPanel.Controls.Clear();
            controlPanel.Controls.Add(c);

        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            var ucaa = new UC_AdminAuthors();
            AddControlsToPanel(ucaa);
        }

        private void authorsButton_Click(object sender, EventArgs e)
        {
            var ucaa = new UC_AdminAuthors();
            AddControlsToPanel(ucaa);
        }

        private void bookStoresButton_Click(object sender, EventArgs e)
        {
            var ucabs = new UC_AdminBookStores();
            AddControlsToPanel(ucabs);
        }
    }
}
