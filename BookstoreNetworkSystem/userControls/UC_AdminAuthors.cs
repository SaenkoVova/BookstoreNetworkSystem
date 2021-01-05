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
    public partial class UC_AdminAuthors : UserControl
    {
        public UC_AdminAuthors()
        {
            InitializeComponent();
        }

        private void UC_AdminAuthors_Load(object sender, EventArgs e)
        {
            var col1 = new DataGridViewTextBoxColumn();
            var col2 = new DataGridViewTextBoxColumn();
            var col3 = new DataGridViewTextBoxColumn();
            col1.ReadOnly = true;
            col1.HeaderText = "№";
            col2.HeaderText = "Ім'я";
            col3.HeaderText = "Прізвище";
            col3.Name = "Author";
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
                col1, col2, col3
            });
            using (var context = new MyDbContext())
            {
                var authors = context.Authors.ToList();
                foreach(var a in authors)
                {
                    dataGridView1.Rows.Add(a.Id, a.FirstName, a.SecondName);
                }
            }
            dataGridView1.Rows.Add();
            dataGridView1.CurrentCell.Selected = false;
        }

        private void addAuthorBtn_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.Rows[dataGridView1.Rows.Count - 1];
            if (row.Cells[1].Value == null || row.Cells[2].Value == null)
            {
                row.ErrorText = "Усі поля мають бути заповнені";
                return;
            }
            using (var context = new MyDbContext())
            {
                var author = new Author
                {
                    FirstName = row.Cells[1].Value.ToString(),
                    SecondName = row.Cells[2].Value.ToString()
                };
                context.Authors.Add(author);
                context.SaveChanges();
                MessageBox.Show("Автора додано до бази даних");
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
                var authorId = Convert.ToInt32(e.Row.Cells[0].Value);
                var author = context.Authors.Find(authorId);
                context.Authors.Remove(author);
                context.SaveChanges();
                MessageBox.Show("Автора видалено");
            }
        }
    }
}
