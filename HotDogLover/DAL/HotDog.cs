//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotDogLover.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class HotDog
    {
        public HotDog()
        {
            this.Profiles = new HashSet<Profile>();
        }
    
        public decimal HotDogID { get; set; }
        public string Name { get; set; }
        public System.DateTime LastAte { get; set; }
        public string LastPlaceAte { get; set; }
    
        public virtual ICollection<Profile> Profiles { get; set; }
    }
}