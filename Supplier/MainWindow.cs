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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
        }

        #region Вспомогательные функции и закрытие окна

        public void ShowLoginForm()
        {
            if (Owner is LoginWindow loginWindow)
            {
                loginWindow.ShowForm();
                Visible = false;
            }
        }

        public void ShowForm()
        {
            this.Visible = true;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = MessageBox.Show("Закрыть форму?", "Внимание потеря данных!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (DialogResult == DialogResult.OK)
            {
                ShowLoginForm();
                GC.Collect();
            }
            if (DialogResult == DialogResult.Cancel)
            {
                e.Cancel = true;
            }

        }
        #endregion
    }
}
