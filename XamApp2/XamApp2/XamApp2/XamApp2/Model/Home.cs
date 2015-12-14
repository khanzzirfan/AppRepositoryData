using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamApp2.Model
{
    public class Home
    {
        public Home(string _searchText, string _description, string _image)
        {
            this.OptionSearch = _searchText;
            this.Description = _description;
            this.Image = _image;
        }
        public string OptionSearch { private set; get; }
        public string Description { private set; get; }
        public string Image { private set; get; }
    }

    public class President
   {
       public President(string name, int position, string image)
       {
           this.Name = name;
           this.Position = position;
           this.Image = image;
       }

       public string Name { private set; get; }

       public int Position { private set; get; }

       public string Image { private set; get; }
   };


}
