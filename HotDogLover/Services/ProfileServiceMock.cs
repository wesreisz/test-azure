using HotDogLover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotDogLover.Services
{
    public class ProfileServiceMock
    {
        private static List<Profile> profiles;
        private static HotDogService hotDogService;
        static ProfileServiceMock() {
            reload();
        }

       
        public List<Profile> ListAll() {
            return profiles;
        }
        public Profile Get(int id) {
            Profile foundProfile = new Profile();
            foreach (Profile profile in profiles) {
                if (profile.ProfileID == id) {
                    foundProfile = profile;
                }
            }
            return foundProfile;
        }
        public void Add(Profile profile) {
            if (profile == null)
            {
                return;
            }

            profiles.Add(profile);
        }

        public void AddDog(Profile profile, HotDog dog) {
            Profile p = Get(profile.ProfileID);
            p.HotDogList.Add(dog);
            
        }
        public void Remove(Profile profile)
        {
            //trap for null objects
            if (profile == null)
            {
                return;
            }

            //find the profile to whack
            Profile profileToRemove = null;
            foreach (Profile p in profiles) {
                if (p.ProfileID == profile.ProfileID) {
                    profileToRemove = p;
                }
            }
            //whack profile
            if (profileToRemove != null) {
                profiles.Remove(profileToRemove);
            }
        }
        public void Update(Profile profile) {
            Profile profileToUpdate = Get(profile.ProfileID);
          
            profileToUpdate.Name = profile.Name;
            profileToUpdate.Picture = profile.Picture;
            profileToUpdate.Bio = profile.Bio;

            Remove(profile);
            Add(profileToUpdate);
        }
        public static void reload()
        {
            hotDogService = new HotDogService();
            profiles = new List<Profile>();

            List<HotDog> myFavs = new List<HotDog>();
            myFavs.Add(hotDogService.Get(1));
            myFavs.Add(hotDogService.Get(2));
            myFavs.Add(hotDogService.Get(3));

            Profile p1 = new Profile()
            {
                Name = "Wesley Reisz",
                Bio = "Bacon ipsum dolor amet brisket shankle ribeye hamburger shoulder alcatra. Leberkas beef turkey, tail pork chop flank porchetta shankle turducken. Pancetta salami frankfurter, leberkas pork chop ham hock shoulder short loin strip steak brisket pork belly capicola ground round spare ribs rump. Andouille alcatra cow pork chop cupim, pancetta capicola shank. Andouille picanha pastrami biltong ham. Meatball sirloin shank cow short loin doner. Pork strip steak boudin ham leberkas fatback. Strip steak pork loin meatloaf shoulder capicola fatback. Strip steak capicola hamburger, ground round kielbasa t-bone ham hock ham. Meatball rump sausage drumstick turkey pastrami filet mignon pig biltong. Jowl kielbasa bacon kevin, jerky filet mignon pork chop chuck chicken beef pig shoulder. Tail alcatra porchetta chicken jowl doner meatball. Tongue shank andouille ribeye, alcatra tail meatball picanha porchetta pancetta pastrami kevin.",
                Picture = "http://www.wesleyreisz.com/images/atsea.jpg",
                ProfileID = 1,
                FavoriteHotDog = hotDogService.Get(1),
                HotDogList = myFavs
            };
            profiles.Add(p1);

            myFavs = new List<HotDog>();
            myFavs.Add(hotDogService.Get(1));
            myFavs.Add(hotDogService.Get(3));

            Profile p2 = new Profile()
            {
                Name = "Bobby Bacon",
                Bio = "Bacon ipsum dolor amet brisket shankle ribeye hamburger shoulder alcatra. Leberkas beef turkey, tail pork chop flank porchetta shankle turducken. Pancetta salami frankfurter, leberkas pork chop ham hock shoulder short loin strip steak brisket pork belly capicola ground round spare ribs rump. Andouille alcatra cow pork chop cupim, pancetta capicola shank. Andouille picanha pastrami biltong ham. Meatball sirloin shank cow short loin doner. Pork strip steak boudin ham leberkas fatback. Strip steak pork loin meatloaf shoulder capicola fatback. Strip steak capicola hamburger, ground round kielbasa t-bone ham hock ham. Meatball rump sausage drumstick turkey pastrami filet mignon pig biltong. Jowl kielbasa bacon kevin, jerky filet mignon pork chop chuck chicken beef pig shoulder. Tail alcatra porchetta chicken jowl doner meatball. Tongue shank andouille ribeye, alcatra tail meatball picanha porchetta pancetta pastrami kevin.",
                Picture = "http://blog.estately.com/assets/kevin-bacon-art-jason-mecier.jpg",
                ProfileID = 2,
                FavoriteHotDog = hotDogService.Get(3),
                HotDogList = myFavs
            };
            profiles.Add(p2);

            myFavs = new List<HotDog>();
            myFavs.Add(hotDogService.Get(2));

            Profile p3 = new Profile()
            {
                Name = "Valorie Vegan",
                Bio = "Veggies es bonus vobis, proinde vos postulo essum magis kohlrabi welsh onion daikon amaranth tatsoi tomatillo melon azuki bean garlic. Gumbo beet greens corn soko endive gumbo gourd. Parsley shallot courgette tatsoi pea sprouts fava bean collard greens dandelion okra wakame tomato. Dandelion cucumber earthnut pea peanut soko zucchini. Turnip greens yarrow ricebean rutabaga endive cauliflower sea lettuce kohlrabi amaranth water spinach avocado daikon napa cabbage asparagus winter purslane kale. Celery potato scallion desert raisin horseradish spinach carrot soko. Lotus root water spinach fennel kombu maize bamboo shoot green bean swiss chard seakale pumpkin onion chickpea gram corn pea. Brussels sprout coriander water chestnut gourd swiss chard wakame kohlrabi beetroot carrot watercress. Corn amaranth salsify bunya nuts nori azuki bean chickweed potato bell pepper artichoke. Nori grape silver beet broccoli kombu beet greens fava bean potato quandong celery. Bunya nuts black-eyed pea prairie turnip leek lentil turnip greens parsnip. Sea lettuce lettuce water chestnut eggplant winter purslane fennel azuki bean earthnut pea sierra leone bologi leek soko chicory celtuce parsley jÃ­cama salsify. Celery quandong swiss chard chicory earthnut pea potato. Salsify taro catsear garlic gram celery bitterleaf wattle seed collard greens nori. Grape wattle seed kombu beetroot horseradish carrot squash brussels sprout chard.",
                Picture = "http://delavegart.com/communities/3/000/001/042/293//images/6013306.jpg",
                ProfileID = 3,
                FavoriteHotDog = hotDogService.Get(2),
                HotDogList = myFavs
            };
            profiles.Add(p3);
        }
    }
}