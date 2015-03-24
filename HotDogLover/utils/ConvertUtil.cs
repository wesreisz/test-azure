using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotDogLover.utils
{
    public class ConvertUtil
    {
        public static DAL.HotDog hotdogmodel2dal(Models.HotDog model){
            DAL.HotDog dal = new DAL.HotDog() { 
                HotDogID=model.HotDogID,
                LastPlaceAte=model.LastPlaceAte,
                LastAte=model.LastTimeAte,
                Name=model.HotDogName
            };
            return dal;
        }
        public static DAL.Profile profilemodel2dal(Models.Profile model)
        {
            DAL.Profile dal = new DAL.Profile()
            {
                Bio=model.Bio,
                HotDogID=model.FavoriteHotDog.HotDogID,
                Name=model.Name,
                Picture=model.Picture,
                ProfileID=model.ProfileID
            };
            //convert the existing dogs
            List<DAL.HotDog> dalDogs = new List<DAL.HotDog>();
            foreach (Models.HotDog modelDog in model.HotDogList) {
                DAL.HotDog dalDog = hotdogmodel2dal(modelDog);
                dalDogs.Add(dalDog);
            }
            dal.HotDogs = dalDogs;
            return dal;
        }
    }
}