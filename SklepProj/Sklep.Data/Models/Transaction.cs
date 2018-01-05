using System;
using System.Globalization;

namespace Sklep.Data.Models
{
    /// <summary>
    ///     Symbolizuje pojedyńczą transakcje
    /// </summary>
    public class Transaction
    {
        public Transaction()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        ///     Identyfikator transakcji
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Data zakupu
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Suma
        /// </summary>
        public double Sum { get; set; }

        public override string ToString()
        {

            return $"{Date.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}