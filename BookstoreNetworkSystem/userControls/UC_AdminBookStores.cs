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

namespace BookstoreNetworkSystem.userControls
{
    public partial class UC_AdminBookStores : UserControl
    {
        public UC_AdminBookStores()
        {
            InitializeComponent();
        }

        private void UC_AdminBookStores_Load(object sender, EventArgs e)
        {
            var col1 = new DataGridViewTextBoxColumn();
            var col2 = new DataGridViewTextBoxColumn();
            var col3 = new DataGridViewTextBoxColumn();
            var col4 = new DataGridViewTextBoxColumn();
            col1.ReadOnly = true;
            col1.HeaderText = "№";
            col2.HeaderText = "Назва";
            col3.HeaderText = "Адреса";
            col4.HeaderText = "Телефон";
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
                col1, col2, col3, col4
            });
            using (var context = new MyDbContext())
            {
                var bookStores = context.BookStores.ToList();
                foreach (var bs in bookStores)
                {
                    dataGridView1.Rows.Add(bs.Id, bs.Name, bs.Address, bs.Phone);
                }
            }
            dataGridView1.Rows.Add();
            dataGridView1.CurrentCell.Selected = false;
        }

        private void addBookStoreBtn_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.Rows[dataGridView1.Rows.Count - 1];
            if (row.Cells[1].Value == null || row.Cells[2].Value == null ||
                row.Cells[3].Value == null)
            {
                row.ErrorText = "Усі поля мають бути заповнені";
                return;
            }
            using (var context = new MyDbContext())
            {
                var bookStore = new BookStore
                {
                    Name = row.Cells[1].Value.ToString(),
                    Address = row.Cells[2].Value.ToString(),
                    Phone = row.Cells[3].Value.ToString()
                };
                context.BookStores.Add(bookStore);
                context.SaveChanges();
                MessageBox.Show("Книгарню додано до бази даних");
                dataGridView1.Rows.Add();
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var lastRow = dataGridView1.Rows[dataGridView1.Rows.Count - 1];
            if (dataGridView1.SelectedRows.Contains(lastRow))
            {
                MessageBox.Show("Не можна видаляти останній рядок");
                e.Cancel = true;
                return;
            }
            using (var context = new MyDbContext())
            {
                var bookStoreId = Convert.ToInt32(e.Row.Cells[0].Value);
                var bookStore = context.BookStores.Find(bookStoreId);
                context.BookStores.Remove(bookStore);
                context.SaveChanges();
                MessageBox.Show("Книгарню видалено");
            }
        }
    }
}
