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

namespace BookstoreNetworkSystem.userControls
{
    public partial class UC_BookStore : UserControl
    {
        public int BookId { get; set; }
        public int UserId { get; }
        public UC_BookStore(User user)
        {
            InitializeComponent();
            UserId = user.Id;
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
            favouriteButton.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using(var context = new MyDbContext())
            {
                dataGridView1.Rows.Clear();
                int id = Convert.ToInt32(comboBox1.Text[0].ToString());
                foreach (BookStore bs in context.BookStores.Where(bs => bs.Id == id).Include(bs => bs.Books))
                {
                    foreach (Book b in bs.Books)
                    {
                        var author = context.Authors.Where(a => a.Id == b.AuthorId).ToArray();
                        dataGridView1.Rows.Add(b.Id, b.Title, author[0].FirstName + " " + 
                            author[0].SecondName, b.Price, b.Date);
                    }
                }
            }
        }

        private void UC_BookStore_Load(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                var bookStores = context.BookStores.ToArray();
                foreach (var item in bookStores)
                {
                    comboBox1.Items.Add($"{item.Id}, Книгарня: {item.Name}, Адреса: {item.Address}, Телефон: " +
                        $"{item.Phone}");
                }
                comboBox1.Text = $"{bookStores[0].Id}, Книгарня: {bookStores[0].Name}, Адреса: {bookStores[0].Address}" +
                    $", Телефон: {bookStores[0].Phone}";

            }
            dataGridView1.CurrentCell.Selected = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int bookCounter = 0;
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string id = row.Cells[0].Value.ToString();
                BookId = Convert.ToInt32(id);
                using (var context = new MyDbContext())
                {
                    foreach (User u in context.Users.Where(u => u.Id == UserId).Include(u => u.Books))
                    {
                        foreach (Book b in u.Books.Where(b => b.Id == BookId))
                        {
                            bookCounter++;
                        }
                    }
                }
                if(bookCounter > 0)
                {
                    favouriteButton.Enabled = false;
                    favouriteButton.Text = $"Книга вже додана";
                    favouriteButton.BackColor = Color.FromArgb(178, 8, 75);
                    return;
                }
                favouriteButton.Enabled = true;
                favouriteButton.BackColor = Color.FromArgb(182, 172, 0);
                favouriteButton.Text = $"Додати книгу {id} до улюблених";
            }
        }

        private void favouriteButton_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                var candidate = context.Users.Where(u => u.Id == UserId).ToArray();
                var book = context.Books.Where(b => b.Id == BookId).ToArray();
                candidate[0].Books.Add(book[0]);
                context.SaveChanges();
                MessageBox.Show($"Книга: {book[0].Title} додана до улубленого");
                favouriteButton.BackColor = Color.FromArgb(178, 8, 75);
                favouriteButton.Enabled = false;
            }
        }
    }
}
