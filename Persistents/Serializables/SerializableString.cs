using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistents.Serializable
{
    class SerializableString : ISerializable
    {
        public string Value { get; set; }

        public SerializableString(string value)
        {
            Value = value;
        }


        public void Deserialize(byte[] bytes)
        {
            Value = Encoding.ASCII.GetString(bytes);
        }

        public byte[] Serialize()
        {
            return Encoding.ASCII.GetBytes(Value);
        }

        public static implicit operator string(SerializableString serializableString) => serializableString.Value;
        public static implicit operator SerializableString(string @string) => new SerializableString(@string);
        
    }
}
