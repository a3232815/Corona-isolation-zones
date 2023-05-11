using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using שרת_שנה_ג.Models;

namespace שרת_שנה_ג.ef
{
    public class DB
    {
      
        public static List<Person> allPersones()
        {
            try
            {
                using (Corona_DBEntities db = new Corona_DBEntities())
                {
                    var result = from p in db.Person_tb
                                 join c in db.City_tb on p.CityId equals c.CityId
                                 join s in db.Street_tb on p.StreetId equals s.StreetId
                                 join i in db.Image_tb on p.ImageId equals i.ImageID into imageData
                                 //equals to "left join" in SQL)
                                 from img in imageData.DefaultIfEmpty()
                                 select new Person
                                 {
                                     PersonId = p.PersonId,
                                     FirstName = p.FirstName,
                                     LastName = p.LastName,
                                     CityName = c.CityName,
                                     StreetName = s.StreetName,
                                     HouseNumber = p.HouseNumber,
                                     DateOfBirth = p.DateOfBirth,
                                     Phone = p.phone,
                                     MobilePhone = p.MobilePhone,
                                     //if img empty defines thut ImageData equals "null",
                                     //If we don't set it the entire query will return an empty array
                                     ImageDate = img == null ? null : img.ImageData
                                 };
                    return result.ToList();
                }
            }
            catch (DbException exp)
            {
                // Log what you need from here.
                throw new InvalidOperationException("Data could not be read allPersones", exp);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }



        }

        //public static List<CoronaDetails> c = new List<CoronaDetails>();

        public static List<CoronaDetails> allCoronaDetails()
        {
            try
            {
                using (Corona_DBEntities db = new Corona_DBEntities())
                {
                    var result = from c in db.CoronaDetails_tb
                                 join p in db.Person_tb on c.PersonId equals p.PersonId
                                 join m in db.manufacturerVaccine_tb on c.manufacturerVaccineId equals m.manufacturerId into manufacturer
                                 //equals to "left join" in SQL)
                                 from m in manufacturer.DefaultIfEmpty()
                                 select new CoronaDetails
                                 {
                                     CoronaDetailsId = c.CoronaDetailsId,
                                     PersonId = p.PersonId,
                                     //This field is to illustrate that since "corona details" inherits from "person" ,
                                     //it is possible to display the "person" fields in this query
                                     FirstName = p.FirstName,
                                     vaccinationDate1 = c.vaccinationDate1,
                                     vaccinationDate2 = c.vaccinationDate2,
                                     vaccinationDate3 = c.vaccinationDate3,
                                     vaccinationDate4 = c.vaccinationDate4,
                                     Manufacturer = m != null ? m.manufacturer : null,
                                     positiveResultDate = c.positiveResultDate,
                                     recoveryDate = c.recoveryDate
                };
                    return result.ToList();
                }
            }
            catch (DbException exp)
            {
                
                throw new InvalidOperationException("Data could not be read allCoronaDetails", exp);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        public static Person GetPerson(string id)
        {
            try
            {
                using (Corona_DBEntities db = new Corona_DBEntities())
                {
                    IEnumerable<Person> all = allPersones();

                    return all.FirstOrDefault((x) => x.PersonId == id);
                }
            }
            catch (DbException exp)
            {

                throw new InvalidOperationException("Data could not be read allCoronaDetails", exp);
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            
        }
        public static CoronaDetails GetCoronaDetails(int CoronaDetailsId)
        {
            try
            {
                using (Corona_DBEntities db = new Corona_DBEntities())
                {
                    IEnumerable<CoronaDetails> all =allCoronaDetails();
                    return all.FirstOrDefault((CoronaDetails) => CoronaDetails.CoronaDetailsId == CoronaDetailsId);
                }
            }
            catch (DbException exp)
            {

                throw new InvalidOperationException("Data could not be read allCoronaDetails", exp);
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        //public static string addPerson(int personId, string firstName, string lastName, string cityName, string streetName,
        //    short houseNumber, System.DateTime dateOfBirth, string phone, string mobilePhone, byte[] ImageDate=null)
        //{
        //    using (Corona_DBEntities db = new Corona_DBEntities())
        //    {
        //        int cityId = -1, streetId = -1, imageId = -1;
        //        cityId = db.City_tb.FirstOrDefault((city) => city.CityName == cityName).CityId;
        //        streetId = db.Street_tb.FirstOrDefault((street) => street.StreetName == streetName).StreetId;
        //        imageId = ImageDate == null ? -1 : db.Image_tb.FirstOrDefault((image) => image.ImageData == ImageDate).ImageID;
        //        if (cityId < 0)
        //            return "error city name";
        //        if (streetId < 0)
        //            return "error street name";
        //        db.Person_tb.Add(new Person_tb(personId, firstName, lastName, cityId, streetId,
        //        houseNumber, dateOfBirth, phone, mobilePhone, imageId));
        //        db.SaveChanges();
        //        return "0";
        //    }
        //}
        public static string addPerson(Person_tb p)
        {
            using (Corona_DBEntities db = new Corona_DBEntities())
            {
                
                db.Person_tb.Add(p);
                db.SaveChanges();
                return "0";
            }
        }
        public static string addCoronaDetails(CoronaDetails_tb c)
        {
            using (Corona_DBEntities db = new Corona_DBEntities())
            {

                db.CoronaDetails_tb.Add(c);
                db.SaveChanges();
                return "0";
            }
        }

    }
}