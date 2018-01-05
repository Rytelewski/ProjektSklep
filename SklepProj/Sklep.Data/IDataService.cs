using System.Collections.Generic;
using Sklep.Data.Models;

namespace Sklep.Data
{
    public interface IDataService
    {
        List<ShopEntity> ShopEntities { get; set; }

        List<Transaction> Transactions { get; set; }

        List<ShopEntity> GetTransactionEntities(Transaction transaction);

        void SaveTransactionEntities(Transaction transaction, IEnumerable<ShopEntity> entites);

        void Load();

        void Save();
    }
}