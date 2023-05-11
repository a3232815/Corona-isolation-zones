using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace שרת_שנה_ג.Models
{
    public class CoronaDetails
    {
        public int CoronaDetailsId { get; set; }
        public string PersonId { get; set; }
        public Nullable<System.DateTime> vaccinationDate1 { get; set; }
        public Nullable<System.DateTime> vaccinationDate2 { get; set; }
        public Nullable<System.DateTime> vaccinationDate3 { get; set; }
        public Nullable<System.DateTime> vaccinationDate4 { get; set; }
        public Nullable<System.DateTime> positiveResultDate { get; set; }
        public Nullable<System.DateTime> recoveryDate { get; set; }       
        public string FirstName { get; set; }        
        public string Manufacturer { get; set; }

        public CoronaDetails() { }
        public CoronaDetails(int coronaDetailsId, string personId, DateTime? vaccinationDate1, DateTime? vaccinationDate2, DateTime? vaccinationDate3, DateTime? vaccinationDate4, int? manufacturerVaccineId, DateTime? positiveResultDate, DateTime? recoveryDate, string firstName, string manufacturer)
        {
            CoronaDetailsId = coronaDetailsId;
            PersonId = personId;
            this.vaccinationDate1 = vaccinationDate1;
            this.vaccinationDate2 = vaccinationDate2;
            this.vaccinationDate3 = vaccinationDate3;
            this.vaccinationDate4 = vaccinationDate4;
            this.positiveResultDate = positiveResultDate;
            this.recoveryDate = recoveryDate;
            FirstName = firstName;
            Manufacturer = manufacturer;
        }

    }
}