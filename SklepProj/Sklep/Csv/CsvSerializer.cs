using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using Sklep.Core;

namespace Sklep.Csv
{
    public class CsvSerializer : ICsvSerializer
    {
        public void SerializeCollection<T>(IEnumerable<T> collection, string path)
        {
            using (var fileStream = File.Open(path, FileMode.Create, FileAccess.Write))
            {
                using (var streamReader = new StreamWriter(fileStream))
                {
                    using (var csvReader = new CsvWriter(streamReader))
                    {
                        csvReader.WriteRecords(collection);
                    }
                }
            }
        }

        public void Serialize<T>(T element, string path)
        {
            using (var fileStream = File.Open(path, FileMode.Create, FileAccess.Write))
            {
                using (var streamReader = new StreamWriter(fileStream))
                {
                    using (var csvReader = new CsvWriter(streamReader))
                    {
                        csvReader.WriteRecord(element);
                    }
                }
            }
        }

        public ICollection<T> DeserializeCollection<T>(string path)
        {
            using (var fileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    using (var csvReader = new CsvReader(streamReader))
                    {
                        return csvReader.GetRecords<T>().ToList();
                    }
                }
            }
        }

        public T Deserialize<T>(string path)
        {
            using (var fileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    using (var csvReader = new CsvReader(streamReader))
                    {
                        return csvReader.GetRecord<T>();
                    }
                }
            }
        }
    }
}