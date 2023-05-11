using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace שרת_שנה_ג.ef
{
    public partial class Person_tb
    {
        public Person_tb(string personId,string firstName,string lastName, int cityId, int streetId, 
            short houseNumber, System.DateTime dateOfBirth, string phone,string mobilePhone, int imageId=-1)
        {
            this.PersonId = personId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.StreetId = streetId;
            this.HouseNumber = houseNumber;
            this.CityId = cityId;
            this.DateOfBirth = dateOfBirth;
            this.phone = phone;
            this.MobilePhone = mobilePhone;
            this.ImageId = ImageId;
        }    
    }
}