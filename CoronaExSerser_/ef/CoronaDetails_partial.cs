using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace שרת_שנה_ג.ef
{
    public partial class CoronaDetails_tb
    //The object "Corona details" belongs to a certain person
    {
        public CoronaDetails_tb() { }
        public CoronaDetails_tb(int CoronaDetailsId,
            int PersonId,System.DateTime? vaccinationDate1 = null, System.DateTime? vaccinationDate2 = null, 
            System.DateTime? vaccinationDate3 = null, 
            System.DateTime? vaccinationDate4 = null, int manufacturerId = 0,
            System.DateTime? positiveResultDate = null, System.DateTime? recoveryDate = null) 
        {
            this.CoronaDetailsId = CoronaDetailsId;
            PersonId = PersonId;
            this.vaccinationDate1 = vaccinationDate1 != null ? vaccinationDate1:null;
            this.vaccinationDate2 = vaccinationDate2 != null ? vaccinationDate1 : null;
            this.vaccinationDate3 = vaccinationDate3 != null ? vaccinationDate1 : null;
            this.vaccinationDate4 = vaccinationDate4 != null ? vaccinationDate1 : null;
            this.manufacturerVaccineId = manufacturerId;
            this.positiveResultDate = positiveResultDate != null ? positiveResultDate : null;
            this.recoveryDate = recoveryDate != null ? recoveryDate : null;

        }
    }    
}