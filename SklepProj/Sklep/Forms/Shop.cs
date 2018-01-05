using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Sklep.Csv;
using Sklep.Data;
using Sklep.Data.Models;
using Sklep.Extensions;

namespace Sklep.Forms
{
    public partial class Shop : Form
    {
        private readonly List<ShopEntity> _cart;
        private readonly List<ShopEntity> _productsCopy;

        private string _lastSelectedRowId = string.Empty;

        private readonly BindingSource _bs;

        private readonly IDataService _dataService = CsvDataService.Instance;

        public Shop()
        {
            InitializeComponent();


            _productsCopy = _dataService.ShopEntities.ConvertAll(x => x.Clone() as ShopEntity);

            _bs = new BindingSource { DataSource = _productsCopy };

            shopEntityBindingSource.DataSource = _bs;

            _cart = new List<ShopEntity>();
        }

        private void Filter()
        {
            if (string.IsNullOrEmpty(input_search.Text))
                shopEntityBindingSource.DataSource = _productsCopy;
            ;

            var searchBy = input_search.Text.Split(' ');

            shopEntityBindingSource.DataSource = _productsCopy
                .Where(x =>
                    x.ItemCode.ContainsAny(searchBy) ||
                    x.Amout.ToString().ContainsAny(searchBy) ||
                    x.Description.ToLower().ContainsAny(searchBy) ||
                    x.Name.ToLower().ContainsAny(searchBy) ||
                    x.Price.ToString(CultureInfo.InvariantCulture).ContainsAny(searchBy) ||
                    x.PublishDate.ToString(CultureInfo.InvariantCulture).ContainsAny(searchBy) ||
                    x.Publisher.ToString().ContainsAny(searchBy) ||
                    x.Type.ToString().ContainsAny(searchBy)
                );
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void input_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Filter();
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
            {
                gridContextMenu.Show(Cursor.Position.X, Cursor.Position.Y);

                _lastSelectedRowId = _productsCopy[e.RowIndex].ItemCode;
            }
        }

        private void HandleAddToCart(ShopEntity entity)
        {
            var product = _productsCopy.FirstOrDefault(x => x.ItemCode == entity.ItemCode);

            if (product != null)
            {
                product.Amout = product.Amout - entity.Amout;

                if (product.Amout < 1)
                {
                    _productsCopy.Remove(product);
                    _bs.ResetBindings(false);
                }
                else
                {
                    dataGridView1.Refresh();
                }

                listBox_cart.Items.Add(entity);
                _cart.Add(entity);
                UpdateCartSumLabel();
            }
        }

        private void HandleRemoveFromCart(ShopEntity entity)
        {
            var product = _productsCopy.FirstOrDefault(x => entity.ItemCode == x.ItemCode);
            if (product != null)
            {
                product.Amout = product.Amout + entity.Amout;
                dataGridView1.Refresh();
            }
            else
            {
                _productsCopy.Add(entity);
                _bs.ResetBindings(false);
            }

            _cart.Remove(entity);
            listBox_cart.Items.Remove(entity);

            UpdateCartSumLabel();
        }

        private void UpdateCartSumLabel()
        {
            lbl_cart_sum.Text = CountCartSum().ToString(CultureInfo.InvariantCulture) + " zł";
            ;
        }

        private double CountCartSum()
        {
            return _cart.Sum(x => x.Amout * x.Price);
        }


        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var entity = _productsCopy
                .FirstOrDefault(x => x.ItemCode == _lastSelectedRowId);

            var form = new AddProductWindow(entity);

            form.OnItemAdded += HandleAddToCart;

            form.Closed += (o, args) => { Enabled = true; };

            Enabled = false;

            form.Show();
        }

        private void listBox_cart_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var entity = listBox_cart?.SelectedItem as ShopEntity;

            if (entity == null) return;

            HandleRemoveFromCart(entity);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            _dataService.ShopEntities = _productsCopy;

            var transaction = new Transaction
            {
                Sum = CountCartSum(),
                Date = DateTime.Now
            };

            _dataService.Transactions.Add(transaction);

            _dataService.Save();

            _dataService.SaveTransactionEntities(transaction, _cart);

            MessageBox.Show("Dodano");

            this.Close();
        }
    }
}