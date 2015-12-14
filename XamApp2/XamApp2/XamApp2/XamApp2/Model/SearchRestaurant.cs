using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamApp2.Model
{
    public class SearchRestaurant
    {

        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Image { get; set; }

        public SearchRestaurant(string title, string subtitle, string image)
        {
            this.Title = title;
            this.Subtitle = subtitle;
            this.Image = image;
        }
    }
}
