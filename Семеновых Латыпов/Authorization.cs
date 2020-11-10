using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Семеновых_Латыпов
{
    public struct User
    {
        public string login;
        public string password;
        public string type;
    }
    public partial class FormAuthorization : Form
    {
        public static User user = new User();
        public FormAuthorization()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("введите данные", "ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                bool key = false;
                foreach (Users users in Program.cafedb.Users)
                {
                    if (textBoxLogin.Text == users.Name || textBoxPassword.Text == users.Password)
                    {
                        key = true;
                        user.login = users.Name;
                        user.password = users.Password;
                        user.type = users.Type;
                    }
                }
                if (!key)
                {
                    MessageBox.Show("проверьте данные", "пользователь не найден", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxLogin.Text = "";
                    textBoxPassword.Text = "";
                }
                else
                {

                    FormStaff menu = new FormStaff();
                    menu.Show();
                    this.Hide();
                }

            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
