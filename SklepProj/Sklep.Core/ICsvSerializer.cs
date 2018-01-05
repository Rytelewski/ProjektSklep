using System.Collections.Generic;

namespace Sklep.Core
{
    public interface ICsvSerializer
    {
        void SerializeCollection<T>(IEnumerable<T> collection, string path);

        void Serialize<T>(T element, string path);

        ICollection<T> DeserializeCollection<T>(string path);

        T Deserialize<T>(string path);
    }
}