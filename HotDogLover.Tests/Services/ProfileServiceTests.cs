using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotDogLover.Services;
using HotDogLover.Models;
using System.Collections.Generic;

namespace HotDogLover.Tests.Services
{
    [TestClass]
    public class ProfileServiceTests
    {
        [TestMethod]
        public void UpdateProfile()
        {
            ProfileServiceMock profileService = new ProfileServiceMock();
            ProfileServiceMock.reload();
            Profile edittedProfile = profileService.Get(1);
            edittedProfile.Name = "Joey";
            profileService.Update(edittedProfile);
            Profile p1 = profileService.Get(1);
            Assert.AreEqual("Joey", p1.Name);

            List<Profile> profiles = profileService.ListAll();
            Assert.AreEqual(3, profiles.Count);
        }

        [TestMethod]
        public void GetAllProfiles()
        {
            ProfileServiceMock profileService = new ProfileServiceMock();
            ProfileServiceMock.reload();
            List<Profile> profiles = profileService.ListAll();
            Assert.IsNotNull(profiles);
            Assert.AreEqual(3, profiles.Count);
        }
        [TestMethod]
        public void GetProfile()
        {
            ProfileServiceMock profileService = new ProfileServiceMock();
            ProfileServiceMock.reload();
            Profile profile = profileService.Get(1);
            Assert.IsNotNull(profile);
            Assert.AreEqual("Wesley Reisz", profile.Name);
            Assert.AreEqual(3, profile.HotDogList.Count);
        }
        [TestMethod]
        public void AddProfile()
        {
            ProfileServiceMock profileService = new ProfileServiceMock();
            ProfileServiceMock.reload();
            Profile profile = profileService.Get(1);
            profile.Name = "Big Ol test";
            int newId = 100;
            profile.ProfileID = newId;
            profileService.Add(profile);

            List<Profile> profiles = profileService.ListAll();
            Assert.IsNotNull(profiles);
            Assert.AreEqual(4, profiles.Count);

            profile = null;
            profile = profileService.Get(newId);
            profileService.Remove(profile);
            //Assert.IsNull(profileService.Get(newId));
            profiles = profileService.ListAll();
            Assert.IsNotNull(profiles);
            Assert.AreEqual(3, profiles.Count);
        }

     
    }
}
