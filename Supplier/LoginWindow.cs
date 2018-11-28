using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supplier
{
    public partial class LoginWindow : Form
    {
        public static MainWindow _MainWindow = new MainWindow();
        public static string token;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string userName = LoginField.Text;
            string password = PasswordField.Text;

            try
            {
                if (token != null)
                {
                    ShowMainForm();
                    return;
                }
                Dictionary<string, string> tokenDictionary = LoginForm.GetTokenDictionary(userName, password);
                token = tokenDictionary["access_token"];
                Console.WriteLine("{0}", token);
                ShowMainForm();
                LoginForm.GetTokenDictionary(userName, password);
                LoginForm.CreateClient(token);



            }
            catch
            {

            }
            
        }

        #region Вспомогательные функции
        public void ShowForm()
        {
            this.Visible = true;
        }

        public void ShowMainForm()
        {
            if (!_MainWindow.IsDisposed)
            {
                _MainWindow.Owner = this;
                _MainWindow.Show();
                this.Visible = false;
            }
            else
            {
                _MainWindow = new MainWindow
                {
                    Owner = this
                };
                _MainWindow.Show();
                this.Visible = false;
            }
            if (_MainWindow.Visible == false)
            {
                if (!_MainWindow.IsDisposed)
                {
                    _MainWindow.Visible = true;
                }
            }
        }
        #endregion
    }
}
