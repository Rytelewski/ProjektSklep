using System;
using Sklep.Core;

namespace Sklep.Data.Models
{
    /// <summary>
    ///     Bazowa klasa pozycji sklepowej
    /// </summary>
    public class ShopEntity : ICloneable
    {
        private int _amout;

        private double _price;

        public ShopEntity()
        {
            ItemCode = Guid.NewGuid().ToString();
            PublishDate = new DateTime(1980, 2, 2);
        }

        /// <summary>
        ///     Unikalny identyfikator produktu
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        ///     Typ produktu
        /// </summary>
        public ItemType Type { get; set; }

        /// <summary>
        ///     Cena
        /// </summary>
        public double Price
        {
            get => _price;
            set => _price = value < 0 ? 0 : value;
        }

        /// <summary>
        ///     Ilość na magazynie
        /// </summary>
        public int Amout
        {
            get => _amout;
            set => _amout = value < 0 ? 0 : value;
        }

        /// <summary>
        ///     Nazwa
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Data publikacji
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        ///     Wydawca
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        ///     Opis produktu
        /// </summary>
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Nazwa:{Name}       Cena:{Price}zł     Ilość: {Amout}";
        }

        public object Clone()
        {
            return new ShopEntity()
            {
                Amout = this.Amout,
                ItemCode = this.ItemCode,
                Price = this.Price,
                Description = this.Description,
                Name = this.Name,
                PublishDate = this.PublishDate,
                Publisher = this.Publisher,
                Type = this.Type
            };
        }
    }
}