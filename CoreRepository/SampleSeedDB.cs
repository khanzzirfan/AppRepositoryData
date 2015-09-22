using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreRepository
{
    public class SampleSeedDB
    {
        public List<Menu> MenuList { get; set; }
        public SampleSeedDB()
        {
            SeedDb();
        }

        public void SeedDb()
        {
            string d1_dessert_v1 = "https://lh3.googleusercontent.com/-Xh8aY2RRwd0/VeFCHSv2lzI/AAAAAAAAAOY/8SY3a6qk7WM/d1_icecream.png";
            string d1_dessert_v2 = "https://lh3.googleusercontent.com/-5ye--N_DEBA/VbvmwbauncI/AAAAAAAAAMg/jFaE4EWANus/gv_dessertv1.jpg";

            string c1_chicken_v1 = "https://lh3.googleusercontent.com/-fZXGfuTB2UU/VeFCHZIIukI/AAAAAAAAAOo/hgxPzq3_a3c/c1_chicken_afgani.png";
            string c1_chicken_v2 = "https://lh3.googleusercontent.com/-nyuWEiI0BQA/Vb0ilfsVLAI/AAAAAAAAANU/3ElmooO5tdo/gchickenkebab_highres.jpg";
            string c1_chicken_v3 = "https://lh3.googleusercontent.com/-ReuUjC4E6o0/VeFCHdGMYnI/AAAAAAAAAO4/BZB_1NVlEGk/c1_smoke_chicken.png";
            string c1_chicken_v4 = "https://lh3.googleusercontent.com/-cZdvAxn0EyA/VeFCHTm_nQI/AAAAAAAAAOM/UCVCzmAh8Fk/c1_butter_chicken.jpg";
            string c1_chicken_v5 = "https://lh3.googleusercontent.com/-n_v-LXlsC6E/VbvmwT8wk8I/AAAAAAAAAL8/rRlK651PHI8/gv_ctikkav1.jpg";

            string k1_kebab_v1 = "https://lh3.googleusercontent.com/-YPQi3-4I2aY/VeFCHe7dMrI/AAAAAAAAAOM/1wa21O3L2mk/k1_seek_kebab.png";
            string k1_kebab_v2 = "https://lh3.googleusercontent.com/-1qVD5HMsCIU/VbvmwbAgdgI/AAAAAAAAAJ0/f2YLHJGJMZg/gv_Tkebab.jpg";
            string k1_kebab_v3 = "https://lh3.googleusercontent.com/-KCdcg0yKW4s/VeFCHUDg2zI/AAAAAAAAAOM/KNDLaBFVDH4/mx_burito.png";

            string l1_lamb_v1 = "https://lh3.googleusercontent.com/-rqCpTJhJ5QU/VbvmwUus3kI/AAAAAAAAAMM/GvW4J3P5RrE/gv_lambgrid.jpg";
            string gv_vege = "https://lh3.googleusercontent.com/-xaCacbUrAYA/VbvmwR3NZrI/AAAAAAAAAJ0/SQmh3Q3O1y0/gv_vegev1.jpg";
            string gv_side_dish = "https://lh3.googleusercontent.com/-WREcIrGaBYw/VbvmwYA0Z8I/AAAAAAAAAM4/xDmlBcWbfK8/gv_sidedishesv1.jpg";

            #region chickenList
            MenuList = new List<Menu>() {
                new Menu ()
                {
                    Name ="Chicken Afgani",
                    Description ="Afghani Chicken is another specialty recipe of Asian cuisine.",

                    MenuCategory = "Chicken",
                    MenuType="Mains",
                    Price=15.00m,

                    ThumbUrl=c1_chicken_v1,
                },

                new Menu ()
                {
                    Name ="Chicken Kebab",
                    Description ="chicken kebab, better known as ‘tavuk şiş’ (tah-VOOK’ SHEESH’), is often served alongside grilled beef and lamb.",
                    MenuCategory = "Chicken",
                    MenuType="Mains",
                    Price=20.00m,
                    ThumbUrl=c1_chicken_v2,
                },
                new Menu ()
                {
                    Name ="Chicken Smoked",
                    Description ="Smoked Chicken",
                    MenuCategory = "Chicken",
                    MenuType="Mains",
                    Price=15.00m,
                    ThumbUrl=c1_chicken_v3,
                },
                new Menu ()
                {
                    Name ="Butter Chicken",
                    Description ="Smoked Chicken",
                    MenuCategory = "Chicken",
                    MenuType="Mains",
                    Price=15.00m,
                    ThumbUrl=c1_chicken_v4,
                },

                new Menu ()
                {
                    Name ="Chicken Tikka",
                    Description ="Smoked Chicken",
                    MenuCategory = "Chicken",
                    MenuType="Mains",
                    Price=15.00m,
                    ThumbUrl=c1_chicken_v5,
                },

            }; // End of adding MenuList

            #endregion

            #region mainMenuPage --Menu
            MenuList.Add(new Menu()
            {
                Name = "Starters",
                Description = "",
                MenuCategory = "Menu",
                MenuType = "Mains",
                Price = 15.00m,
                ThumbUrl = c1_chicken_v1,
            });

            MenuList.Add(new Menu()
            {
                Name = "Chicken",
                Description = "",
                MenuCategory = "Menu",
                MenuType = "Mains",
                Price = 15.00m,
                ThumbUrl = c1_chicken_v1,
            });
            MenuList.Add(new Menu()
            {
                Name = "Lamb",
                Description = "",
                MenuCategory = "Menu",
                MenuType = "Mains",
                Price = 15.00m,
                ThumbUrl = c1_chicken_v1,
            });

            MenuList.Add(new Menu()
            {
                Name = "Vegetarian",
                Description = "",
                MenuCategory = "Menu",
                MenuType = "Mains",
                Price = 15.00m,
                ThumbUrl = c1_chicken_v1,
            });

            MenuList.Add(new Menu()
            {
                Name = "Seafood",
                Description = "",
                MenuCategory = "Menu",
                MenuType = "Mains",
                Price = 15.00m,
                ThumbUrl = c1_chicken_v1,
            });
            MenuList.Add(new Menu()
            {
                Name = "Desert",
                Description = "",
                MenuCategory = "Menu",
                MenuType = "Mains",
                Price = 15.00m,
                ThumbUrl = c1_chicken_v1,
            });

            MenuList.Add(new Menu()
            {
                Name = "Sides",
                Description = "",
                MenuCategory = "Menu",
                MenuType = "Mains",
                Price = 15.00m,
                ThumbUrl = c1_chicken_v1,
            });
            #endregion


        }
    }
}
