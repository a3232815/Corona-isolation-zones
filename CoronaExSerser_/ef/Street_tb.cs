//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace שרת_שנה_ג.ef
{
    using System;
    using System.Collections.Generic;
    
    public partial class Street_tb
    {
        public Street_tb()
        {
            this.Person_tb = new HashSet<Person_tb>();
        }
    
        public int StreetId { get; set; }
        public string StreetName { get; set; }
    
        public virtual ICollection<Person_tb> Person_tb { get; set; }
    }
}