using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Sklep.Csv;
using Sklep.Data;
using Sklep.Data.Models;

namespace Sklep.Forms
{
    public partial class Admin : Form
    {
        private readonly IDataService _dataService;

        public Admin()
        {
            _dataService = CsvDataService.Instance;

            InitializeComponent();

            shopEntityBindingSource.DataSource = _dataService.ShopEntities;

            transactions_list.DataSource = _dataService.Transactions
                .OrderByDescending(x => x.Date)
                .ToList();
        }

        private void HandleGridError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid != null)
            {
                var column = grid.Columns[e.ColumnIndex];
                MessageBox.Show(
                    $"Wartość w kolumnie {column.HeaderText} jest nieprawidłowa, proszę się sugerować wartością wstępną.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Niespodziewany błąd");
        }

        private void HandleValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var grid = sender as DataGridView;
            var source = grid?.DataSource as BindingSource;

            if (source?.List == null) return;

            var items = source.List
                .Cast<ShopEntity>()
                .ToList();

            if (
                items.Any(x => string.IsNullOrEmpty(x.ItemCode)) ||
                items.Count() != items.Select(x => x.ItemCode).Distinct().Count())
            {
                e.Cancel = true;

                MessageBox.Show("Kod produktu musi być unikalny i nie może być pusty");
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            _dataService.Save();
            MessageBox.Show("Zapisano");
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
            _dataService.Load();
        }

        private void ChangeSelectedTransaction(Transaction transaction)
        {
            if (transaction != null)
            {
                transactionProducts.DataSource = _dataService.GetTransactionEntities(transaction);
                transactionProducts.Refresh();

                txtBox_id.Text = transaction.Id;
                txtBox_data.Text = transaction.Date.ToString(CultureInfo.InvariantCulture);
                txtBox_sum.Text = transaction.Sum.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void transactions_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeSelectedTransaction(transactions_list.SelectedItem as Transaction);
        }

        private void txtBox_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Filter();
            }
        }

        private void Filter()
        {
            if (string.IsNullOrEmpty(txtBox_search.Text))
                transactions_list.DataSource = _dataService.Transactions;
            
            transactions_list.DataSource = _dataService.Transactions
                .Where(x=>x.Date.ToString(CultureInfo.InvariantCulture).Contains(txtBox_search.Text))
                .ToList();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Filter();
        }
    }
}