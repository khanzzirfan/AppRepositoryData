using System;
using CoreRepository.BL.Contracts;
using CoreRepository.DL.SQLite;

namespace CoreRepository.BL
{
    public class BaseOrder : IBusinessEntity
    {
        public BaseOrder()
        {
        }
        
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public bool OrderInProgress { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
