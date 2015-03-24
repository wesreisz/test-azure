using HotDogLover.DAL;
using HotDogLover.Models;
using HotDogLover.utils;
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
            using(var db=new hotdogEntities()){
                var viewProfiles = ( 
                    from profiles in db.Profiles
                    select new Models.Profile()
                    {
                        ProfileID = (int)profiles.ProfileID,
                        Name = profiles.Name,
                        Bio = profiles.Bio,
                        Picture = profiles.Picture
                    }
                );
                return viewProfiles.ToList();
            }

            /*
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
             */ 
        }

        public Models.Profile Get(int id)
        {
              using(var db=new hotdogEntities()){
                  var profile = (
                    from profiles in db.Profiles
                    from hotdogs in profiles.HotDogs
                    where profiles.ProfileID == id
                    select new Models.Profile()
                    {
                        ProfileID = (int)profiles.ProfileID,
                        Name = profiles.Name,
                        Bio = profiles.Bio,
                        Picture = profiles.Picture,
                        HotDogListTmp = (
                                from p in db.Profiles
                                from hd in p.HotDogs
                                select new Models.HotDog() {
                                    HotDogID = (int)hd.HotDogID,
                                    HotDogName = hd.Name,
                                    LastTimeAte = hd.LastAte,
                                    LastPlaceAte = hd.LastPlaceAte
                                }
                            ),
                        FavoriteHotDog = db.HotDogs
                            .Where(x => x.HotDogID == profiles.HotDogID)
                            .Select(h => new Models.HotDog()
                            {
                                HotDogID = (int)h.HotDogID,
                                HotDogName = h.Name,
                                LastTimeAte = h.LastAte,
                                LastPlaceAte = h.LastPlaceAte
                            }).FirstOrDefault()
                    }).FirstOrDefault();
                  //hack to convert IEnumerable to a list
                  profile.HotDogList = profile.HotDogListTmp.ToList();
                  return profile;
                }
            /*
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
             */
        }

        public void Add(Models.Profile profile)
        {
            DAL.Profile profileDAL = ConvertUtil.profilemodel2dal(profile);
            db.SaveChanges();
        }

        public void AddDog(Models.Profile profile, Models.HotDog dog)
        {
            DAL.HotDog hotdogDAL = ConvertUtil.hotdogmodel2dal(dog);

            DAL.Profile profileDAO = db.Profiles.Find(profile.ProfileID);
            profileDAO.HotDogs.Add(hotdogDAL);
            db.SaveChanges();

        }

        public void Remove(Models.Profile profile)
        {
            DAL.Profile profileDAO = db.Profiles.Find(profile.ProfileID);
            db.Profiles.Remove(profileDAO);
            db.SaveChanges();
        }

        public void Update(Models.Profile profile)
        {
            var record2update = db.Profiles.Find(profile.ProfileID);

            if (record2update != null)
            {
                record2update.Name = profile.Name;
                record2update.Picture = profile.Picture;
                record2update.Bio = profile.Bio;
                db.SaveChanges();
            }
        }
    }
}