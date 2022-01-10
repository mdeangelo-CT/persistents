using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistents.Serializable
{
    public class SerializableList<T> : List<T>, ISerializable where T : ISerializable, new()
    {

        public void Deserialize(byte[] bytes)
        {
            RemoveRange(0, this.Count);
            int position = 0;
            while(position < bytes.Length)
            {
                int itemLength = BitConverter.ToInt32(bytes, position);
                position += 4;
                byte[] itemBytes = bytes.SubArray(position, itemLength);
                T item = new T();
                item.Deserialize(itemBytes);
                this.Add(item);
            }
        }

        public byte[] Serialize()
        {
            List<byte> serializedBytes = new List<byte>();
            foreach(var item in this)
            {
                var data = item.Serialize();
                serializedBytes.AddRange(BitConverter.GetBytes(data.Length));
                serializedBytes.AddRange(data);
            }
            return serializedBytes.ToArray();
        }
    }
}
