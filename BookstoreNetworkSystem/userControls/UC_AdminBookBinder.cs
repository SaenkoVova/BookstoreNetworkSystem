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
using static System.Windows.Forms.ListViewItem;

namespace BookstoreNetworkSystem.userControls
{
    public partial class UC_AdminBookBinder : UserControl
    {
        public int BookStoreId { get; set; }
        public UC_AdminBookBinder()
        {
            InitializeComponent();
        }

        private void UC_AdminBookBinder_Load(object sender, EventArgs e)
        {
            string[] columns = { "#", "Заголовок", "Автор", "Дата друку", "Ціна" };
            int i = 0;
            foreach(var c in columns)
            {
                listView1.Columns.Add(c);
                listView2.Columns.Add(c);
                listView1.Columns[i].Width = listView1.Width / 5;
                listView2.Columns[i].Width = listView2.Width / 5;
                i++;
            }
            using (var context = new MyDbContext())
            {
                var books = context.Books.ToList();
                foreach (var b in books)
                {
                    var parent = listView2.Items.Add(b.Id.ToString());
                    parent.SubItems.Add(b.Title);
                    parent.SubItems.Add($"{b.Author.FirstName} {b.Author.SecondName}");
                    parent.SubItems.Add(b.Date);
                    parent.SubItems.Add(b.Price.ToString());
                }
                var bookStores = context.BookStores.ToList();
                foreach (var item in bookStores)
                {
                    comboBox1.Items.Add($"{item.Id}, Книгарня: {item.Name}, Адреса: {item.Address}, Телефон: " +
                        $"{item.Phone}");
                }
                comboBox1.Text = $"{bookStores[0].Id}, Книгарня: {bookStores[0].Name}, Адреса: {bookStores[0].Address}" +
                    $", Телефон: {bookStores[0].Phone}";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            for(int i = 0; i < listView2.Items.Count; i++)
            {
                listView2.Items[i].BackColor = Color.White;
            }
            listView2.BackColor = Color.White;
            using (var context = new MyDbContext())
            {
                int id = Convert.ToInt32(comboBox1.Text[0].ToString());
                BookStoreId = id;
                var bookStore = context.BookStores.Where(bs => bs.Id == id).Include(bs => bs.Books).First();
                foreach (var b in bookStore.Books)
                {
                    var parent = listView1.Items.Add(b.Id.ToString());
                    parent.SubItems.Add(b.Title);
                    parent.SubItems.Add($"{b.Author.FirstName} {b.Author.SecondName}");
                    parent.SubItems.Add(b.Date);
                    parent.SubItems.Add(b.Price.ToString());
                    for(int i = 0; i < listView2.Items.Count; i++)
                    {
                        if (listView2.Items[i].Text == parent.Text)
                        {
                            listView2.Items[i].BackColor = Color.FromArgb(241, 196, 15);
                        }
                    }
                }
            }
            
        }

        private void addToBookStore_Click(object sender, EventArgs e)
        {
            if(listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("Щоб додати книгу в крамницю оберіть її зі списку з права.");
                return;
            }
            int id = Convert.ToInt32(listView2.SelectedItems[0].Text);
            for(int i = 0; i < listView1.Items.Count; i++)
            {
                if(id == Convert.ToInt32(listView1.Items[i].Text))
                {
                    MessageBox.Show("Книга вже була переведена в книгарню.");
                    return;
                }
            }
            listView2.SelectedItems[0].BackColor = Color.FromArgb(241, 196, 15);
            var parent = listView1.Items.Add(listView2.SelectedItems[0].Text);
            int j = 0;
            foreach(ListViewSubItem subitem in listView2.SelectedItems[0].SubItems)
            {
                if (j != 0)
                {
                    parent.SubItems.Add(subitem);
                }
                j++;
            }
            using(var context = new MyDbContext())
            {
                var bookId = Convert.ToInt32(parent.Text);
                var book = context.Books.Where(b => b.Id == bookId).First();
                var bookStore = context.BookStores.Where(bs => bs.Id == BookStoreId).First();
                bookStore.Books.Add(book);
                context.SaveChanges();
                MessageBox.Show("Книгу додано до крамниці");
            }
        }
    }
}
