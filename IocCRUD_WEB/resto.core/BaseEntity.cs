using System;
namespace Resto.Core
{
    public abstract class BaseEntity
    {
        public Guid ID { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string IP { get; set; }
    }
}
