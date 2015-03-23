using HotDogLover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDogLover.Services
{
    interface IProfileService
    {
        List<Profile> ListAll();
        Profile Get(int id);
        void Add(Profile profile);
        void AddDog(Profile profile, HotDog dog);
        void Remove(Profile profile);
        void Update(Profile profile);
    }
}
