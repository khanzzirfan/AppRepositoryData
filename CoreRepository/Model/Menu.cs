using CoreRepository.BL.Contracts;
using CoreRepository.DL.SQLite;

namespace CoreRepository.BL
{
    public class Menu : IBusinessEntity
    {
        public Menu()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string MenuType { get; set; }
        public string MenuCategory { get; set; }
        public string ThumbUrl { get; set; }
        public string LargeUrl { get; set; }
        public string SmallUrl { get; set; }
    }
}
