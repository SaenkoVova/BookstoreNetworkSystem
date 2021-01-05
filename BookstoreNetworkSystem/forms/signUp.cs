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

namespace BookstoreNetworkSystem.forms
{
    public partial class signUp : Form
    {
        public signUp()
        {
            InitializeComponent();
            label3.Text = "";
            label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e74c3c");
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            string login = loginInput.Text;
            string password = passwordInput.Text;
            string passConfirm = passwordConfirmInput.Text;
            if(!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(passConfirm))
            {
                if(!password.Equals(passConfirm))
                {
                    label3.Text = "Паролі не співпадають";
                    return;
                }
                using(var context = new MyDbContext())
                {
                    var candidate = context.Users.Where(c => c.login == login).ToArray();
                    if(candidate.Length != 0)
                    {
                        label3.Text = "Користувач з таким логіном уже існує";
                        return;
                    }
                    var user = new User()
                    {
                        login = login,
                        password = password
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                    var h = new Home(user);
                    h.Show();
                    Hide();
                }
            }
            else
            {
                label3.Text = "Всі поля мають бути заповнені";
            }
        }
    }
}
