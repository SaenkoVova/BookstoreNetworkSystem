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
    public partial class UC_AdminBooks : UserControl
    {
        public UC_AdminBooks()
        {
            InitializeComponent();
        }

        private void UC_AdminBooks_Load(object sender, EventArgs e)
        {
            var col1 = new DataGridViewTextBoxColumn();
            var col2 = new DataGridViewTextBoxColumn();
            var col3 = new DataGridViewComboBoxColumn();
            var col4 = new DataGridViewTextBoxColumn();
            var col5 = new DataGridViewTextBoxColumn();
            col1.ReadOnly = true;
            col1.HeaderText = "№";
            col2.HeaderText = "Назва";
            col3.HeaderText = "Автор";
            col4.HeaderText = "Дата друку";
            col5.HeaderText = "Ціна";
            col3.Name = "Author";
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
                col1, col2, col3, col4, col5
            });
            dataGridView1.Rows.Add();
            using (var context = new MyDbContext())
            {
                int rowsCounter = 0;
                var books = context.Books.ToArray();
                var authors = context.Authors.ToList();
                foreach (Book b in books)
                {
                    DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                    foreach (var a in authors)
                    {
                        l_objGridDropbox.Items.Add($"{a.Id} {a.FirstName} {a.SecondName}");
                    }
                    col3.Items.Clear();
                    col3.Items.AddRange(l_objGridDropbox.Items);
                    var author = context.Authors.Where(a => a.Id == b.AuthorId).FirstOrDefault();
                    l_objGridDropbox.Value = $"{author.Id} {author.FirstName} {author.SecondName}";
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowsCounter].Cells[0].Value = b.Id;
                    dataGridView1.Rows[rowsCounter].Cells[1].Value = b.Title;
                    dataGridView1.Rows[rowsCounter].Cells[2] = l_objGridDropbox;
                    dataGridView1.Rows[rowsCounter].Cells[3].Value = b.Date;
                    dataGridView1.Rows[rowsCounter].Cells[4].Value = b.Price;
                    rowsCounter++;
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void addBookBtn_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.Rows[dataGridView1.Rows.Count - 1];
            if(row.Cells[1].Value == null || row.Cells[2].Value == null ||
                row.Cells[3].Value == null || row.Cells[4].Value == null)
            {
                row.ErrorText = "Усі поля мають бути заповнені";
                return;
            }
            using(var context = new MyDbContext())
            {
                var book = new Book
                {
                    Title = row.Cells[1].Value.ToString(),
                    AuthorId = Convert.ToInt32(row.Cells[2].Value.ToString().Split(' ')[0]),
                    Date = row.Cells[3].Value.ToString(),
                    Price = Convert.ToDouble(row.Cells[4].Value.ToString())
                };
                context.Books.Add(book);
                context.SaveChanges();
                MessageBox.Show("Книгу додано до бази даних");
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
            using(var context = new MyDbContext())
            {
                var bookId = Convert.ToInt32(e.Row.Cells[0].Value);
                var book = context.Books.Find(bookId);
                context.Books.Remove(book);
                context.SaveChanges();
                MessageBox.Show("Книгу видалено");
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
