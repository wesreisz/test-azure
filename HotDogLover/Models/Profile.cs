using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotDogLover.Models
{
    public class Profile
    {
        public int ProfileID { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Picture { get; set; }
        public HotDog FavoriteHotDog { get; set; }
        public List<HotDog> HotDogList { get; set; }
    }
}