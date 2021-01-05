using BookstoreNetworkSystem.forms;
using BookstoreNetworkSystem.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreNetworkSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label3.Text = "";
            label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e74c3c");
        }

        private void signIn_Click(object sender, EventArgs e)
        {
            string login = loginInput.Text;
            string password = passwordInput.Text;
            if(!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                using(var context = new MyDbContext())
                {
                    var user = context.Users.Where(u => u.login == login && u.password == password).ToArray();
                    if(user.Length != 0)
                    {
                        if(user[0].status == false)
                        {
                            var h = new Home(user[0]);
                            h.Show();
                            Hide();
                        }
                        else
                        {
                            var ap = new AdminPanel(user[0]);
                            ap.Show();
                            Hide();

                        }
                    }
                    else
                    {
                        label3.Text = "Невірно вказано логін або пароль";
                    }
                }
            }
            else
            {
                label3.Text = "Всі поля мають бути заповнені";
            }
        }

        private void signUp_Click(object sender, EventArgs e)
        {
            var signUp = new signUp();
            signUp.Show();
            Hide();
        }
    }
}
