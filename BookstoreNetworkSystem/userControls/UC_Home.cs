using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookstoreNetworkSystem.models;
using System.Data.Entity;
using Microsoft.Azure.Management.Network.Models;

namespace BookstoreNetworkSystem.userControls
{
    public partial class UC_Home : UserControl
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public UC_Home(User user)
        {
            InitializeComponent();
            UserId = user.Id;
            favouriteButton.Enabled = false;
            var col1 = new DataGridViewTextBoxColumn();
            var col2 = new DataGridViewTextBoxColumn();
            var col3 = new DataGridViewTextBoxColumn();
            var col4 = new DataGridViewTextBoxColumn();
            var col5 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "№";
            col2.HeaderText = "Назва";
            col3.HeaderText = "Автор";
            col4.HeaderText = "Ціна";
            col5.HeaderText = "Дата друку";
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
                col1, col2, col3, col4, col5
            });
        }

        private void UC_Home_Load(object sender, EventArgs e)
        {
            DownloadData();
            if(dataGridView1.Rows.Count > 0)
            {
                dataGridView1.CurrentCell.Selected = false;
            }
        }

        private void DownloadData()
        {
            using (var context = new MyDbContext())
            {
                dataGridView1.Rows.Clear();
                var user = context.Users.Where(u => u.Id == UserId).Include(u => u.Books).First();
                foreach (Book b in user.Books)
                {
                    dataGridView1.Rows.Add(b.Id, b.Title,
                        $"{b.Author.FirstName} {b.Author.SecondName}", b.Price, b.Date);
                }
            }
        }

        private void favouriteButton_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                var user = context.Users.Find(UserId);
                var book = context.Books.Find(BookId);
                context.Entry(user).Collection("Books").Load();
                user.Books.Remove(book);
                context.SaveChanges();
                DownloadData();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                BookId = Convert.ToInt32(row.Cells[0].Value);
                favouriteButton.Enabled = true;
                favouriteButton.Text = $"Видалити книгу {BookId} з улюблених";
            }
        }
    }
}
