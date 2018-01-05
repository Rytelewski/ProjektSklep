using System;
using System.Globalization;
using System.Windows.Forms;
using Sklep.Data.Models;

namespace Sklep.Forms
{
    public partial class AddProductWindow : Form
    {
        private readonly ShopEntity _entity;

        public AddProductWindow(ShopEntity entity)
        {
            InitializeComponent();

            txtBox_date.Text = entity.PublishDate.ToString(CultureInfo.InvariantCulture);
            txtBox_description.Text = entity.Description;
            txtBox_name.Text = entity.Name;
            txtBox_price.Text = entity.Price.ToString(CultureInfo.InvariantCulture);
            txtBox_productId.Text = entity.ItemCode;
            txtBox_publisher.Text = entity.Publisher;
            txtBox_type.Text = entity.Type.ToString();
            lbl_amout.Text = entity.Amout.ToString();

            numeric_amout.Minimum = 1;
            numeric_amout.Maximum = entity.Amout;

            _entity = entity;
        }

        public event Action<ShopEntity> OnItemAdded;

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //Kopia by mieć niezależy obiekt od tego w liście
            var entity = _entity.Clone() as ShopEntity;

            if (entity != null)
            {
                entity.Amout = (int) numeric_amout.Value;

                OnItemAdded?.Invoke(entity);
            }

            Close();
        }
    }
}