using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace שרת_שנה_ג.Models
{
    public class Person
    {

        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CityName { get; set; }
        public string StreetName { get; set; }
        public short HouseNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public byte[] ImageDate { get; set; }

        public Person() { }

        public Person(string personId, string firstName, string lastName, string cityName, string streetName,
            short houseNumber, DateTime dateOfBirth, string phone, string mobilePhone, byte[] imageDate = null)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
            CityName = cityName;
            StreetName = streetName;
            HouseNumber = houseNumber;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            MobilePhone = mobilePhone;
            ImageDate = imageDate;
        }

        

        
    }

}