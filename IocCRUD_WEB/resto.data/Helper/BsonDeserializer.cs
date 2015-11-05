using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;

namespace Resto.Data.Helper
{
    public class BsonDeserializer:IBsonSerializer 
    {

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            throw new NotImplementedException();
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            throw new NotImplementedException();
        }

        public Type ValueType
        {
            get { throw new NotImplementedException(); }
        }
    }
}
