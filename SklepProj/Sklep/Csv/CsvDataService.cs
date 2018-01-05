using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sklep.Core;
using Sklep.Data;
using Sklep.Data.Models;

namespace Sklep.Csv
{
    public class CsvDataService : IDataService
    {
        private const string DataLocation = "./Data";
        private const string ShopEntitiesLocation = "./Data/ShopEntities.csv";
        private const string TransactionsLocation = "./Data/Transactions.csv";
        private const string TransactionsDataLocation = "./Data/TransactionsData";

        private readonly ICsvSerializer _csvSerializer;

        private static CsvDataService _dataService;

        public static CsvDataService Instance => 
            _dataService ?? (_dataService = new CsvDataService(new CsvSerializer()));


        private CsvDataService(ICsvSerializer csvSerializer)
        {
            _csvSerializer = csvSerializer;

            ShopEntities = new List<ShopEntity>();

            Transactions = new List<Transaction>();

            if (!Directory.Exists(DataLocation))
                Directory.CreateDirectory(DataLocation);

            if (!Directory.Exists(TransactionsDataLocation))
                Directory.CreateDirectory(TransactionsDataLocation);
        }

        public List<ShopEntity> ShopEntities { get; set; }
        public List<Transaction> Transactions { get; set; }

        public List<ShopEntity> GetTransactionEntities(Transaction transaction)
        {
            return _csvSerializer
                .DeserializeCollection<ShopEntity>(Path.Combine(TransactionsDataLocation, transaction.Id) + ".csv")
                .ToList();
        }

        public void SaveTransactionEntities(Transaction transaction, IEnumerable<ShopEntity> entites)
        {
            _csvSerializer
                .SerializeCollection(entites, Path.Combine(TransactionsDataLocation, transaction.Id) + ".csv");
        }

        public void Load()
        {
            ShopEntities = _csvSerializer.DeserializeCollection<ShopEntity>(ShopEntitiesLocation).ToList();

            Transactions = _csvSerializer.DeserializeCollection<Transaction>(TransactionsLocation).ToList();
        }

        public void Save()
        {
            _csvSerializer.SerializeCollection(ShopEntities, ShopEntitiesLocation);

            _csvSerializer.SerializeCollection(Transactions, TransactionsLocation);
        }
    }
}