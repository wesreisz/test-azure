using HotDogLover.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotDogLover.Services
{
    public class ProfileService : IProfileService
    {
        private hotdogEntities db = new hotdogEntities();

        public List<Models.Profile> ListAll()
        {
            List<Models.Profile> viewProfiles = new  List<Models.Profile>();
            Models.HotDog viewHotDog = new Models.HotDog();
            List<DAL.Profile> modelProfiles = db.Profiles.ToList();

            foreach (DAL.Profile modelProfile in modelProfiles) {
                Models.Profile viewProfile = new Models.Profile()
                {
                    Bio=modelProfile.Bio,
                    Name=modelProfile.Name,
                    Picture=modelProfile.Picture,
                    ProfileID = Convert.ToInt32(modelProfile.ProfileID)
                };

                viewProfiles.Add(viewProfile);
            }
            return viewProfiles;
        }

        public Models.Profile Get(int id)
        {
            DAL.Profile modelProfile = db.Profiles.Find(id);
            DAL.HotDog modelHotdog = db.HotDogs.Find(modelProfile.HotDogID);

            ICollection<DAL.HotDog> modelFavoriteHotDogList = modelProfile.HotDogs;
            List<Models.HotDog> viewFavoritHotDogList = new List<Models.HotDog>();
            foreach (DAL.HotDog favoriteHotDog in modelFavoriteHotDogList) {
                Models.HotDog modelFavoriteHotDog = new Models.HotDog() {
                    HotDogID = Convert.ToInt32(favoriteHotDog.HotDogID),
                    HotDogName = favoriteHotDog.Name,
                    LastPlaceAte = favoriteHotDog.LastPlaceAte,
                    LastTimeAte = favoriteHotDog.LastAte,
                    Rating = 5
                };
                viewFavoritHotDogList.Add(modelFavoriteHotDog);
            }

            Models.HotDog viewHotdog = new Models.HotDog(){
                HotDogID= Convert.ToInt32(modelHotdog.HotDogID),
                HotDogName=modelHotdog.Name,
                LastPlaceAte=modelHotdog.LastPlaceAte,
                LastTimeAte=modelHotdog.LastAte,
                Rating=5
            };
            Models.Profile viewProfile = new Models.Profile() {
                Bio = modelProfile.Bio,
                ProfileID = Convert.ToInt32(modelProfile.ProfileID),
                Name = modelProfile.Name,
                Picture = modelProfile.Picture,
                FavoriteHotDog = viewHotdog,
                HotDogList = viewFavoritHotDogList
            };

            return viewProfile;
        }

        public void Add(Models.Profile profile)
        {
            throw new NotImplementedException();
        }

        public void AddDog(Models.Profile profile, Models.HotDog dog)
        {
            throw new NotImplementedException();
        }

        public void Remove(Models.Profile profile)
        {
            throw new NotImplementedException();
        }

        public void Update(Models.Profile profile)
        {
            throw new NotImplementedException();
        }
    }
}