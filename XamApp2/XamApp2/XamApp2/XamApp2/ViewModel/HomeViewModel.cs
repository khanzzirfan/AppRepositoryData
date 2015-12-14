using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamApp2.Model;
using Xamarin.Forms;

namespace XamApp2.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<Home> HomePage { get; set; }
       
        public HomeViewModel(Page page)
            : base(page)
        {
            Title = "Reserve Table";
            // Presidents = new ObservableCollection<President>();
            HomePage = new ObservableCollection<Home>();
            this.LoadList();
        }

        public HomeViewModel()
        {
        
        }

        public void InitializeModel(Page page)
        {
            Title = "Reserve Table";
            // Presidents = new ObservableCollection<President>();
            HomePage = new ObservableCollection<Home>();
            this.LoadList();
        }


        private void LoadList()
        {
            var list = new List<Home>
            {
                new Home("Search For","by restaurant, city, menu","https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"),
                new Home("Saved Places","by restaurant, city, menu","https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"),
                new Home("City Favourite","by restaurant, city, menu","https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"),
            };
            foreach (var homepage in list)
            {
                //if (string.IsNullOrWhiteSpace(store.Image))
                //  store.Image = "http://refractored.com/images/wc_small.jpg";
                HomePage.Add(homepage);
            }

            //// Some presidential data. http://www.americanpresidents.org/gallery/
            //var presidents = new List<President>
            //{
            //    new President("Search For", 1, "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"),
            //    new President("Saved Places", 2, "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"),
            //    new President("City Favourite", 3, "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"),
            //    //new President("James Madison", 4, "http://www.americanpresidents.org/images/04_150.gif"),
            //    //new President("James Monroe", 5, "http://www.americanpresidents.org/images/05_150.gif"),
            //    //new President("John Quincy Adams", 6, "http://www.americanpresidents.org/images/06_150.gif"),
            //    //new President("Andrew Jackson", 7, "http://www.americanpresidents.org/images/07_150.gif"),
            //    //new President("Martin Van Buren", 8, "http://www.americanpresidents.org/images/08_150.gif"),
            //    //new President("William Henry Harrison", 9, "http://www.americanpresidents.org/images/09_150.gif"),
            //    //new President("John Tyler", 10, "http://www.americanpresidents.org/images/10_150.gif"),
            //    //new President("James K. Polk", 11, "http://www.americanpresidents.org/images/11_150.gif"),
            //    //new President("Zachary Taylor", 12, "http://www.americanpresidents.org/images/12_150.gif"),
            //    //new President("Millard Fillmore", 13, "http://www.americanpresidents.org/images/13_150.gif"),
            //    //new President("Franklin Pierce", 14, "http://www.americanpresidents.org/images/14_150.gif"),
            //    //new President("James Buchanan", 15, "http://www.americanpresidents.org/images/15_150.gif"),
            //};

            //foreach (var prez in presidents)
            //{
            //    //if (string.IsNullOrWhiteSpace(store.Image))
            //    //  store.Image = "http://refractored.com/images/wc_small.jpg";
            //    Presidents.Add(prez);
            //}
        }
    }
}
