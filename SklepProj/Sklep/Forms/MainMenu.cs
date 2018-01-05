using System;
using System.Windows.Forms;

namespace Sklep.Forms
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btn_goto_admin_Click(object sender, EventArgs e)
        {
            var adminView = new Admin();

            adminView.Show();
            Hide();
            adminView.FormClosed += (o, args) => { Show(); };
        }

        private void btn_goto_shop_Click(object sender, EventArgs e)
        {
            var shopView = new Shop();

            shopView.Show();
            Hide();
            shopView.FormClosed += (o, args) => { Show(); };
        }
    }
}