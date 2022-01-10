using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistents.Serializable
{
    public interface ISerializable
    {
        byte[] Serialize();
        void Deserialize(byte[] bytes);
    }
}
