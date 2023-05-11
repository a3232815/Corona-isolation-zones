using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data.SqlClient;
using שרת_שנה_ג.Models;
using System.Collections;

namespace שרת_שנה_ג.ef
{
    public class DB_statictics
    {
        public static int AmountNotVaccinated()
        {
            try
            {
                using (Corona_DBEntities db = new Corona_DBEntities())
                {
                    var resulte = db.CoronaDetails_tb.Where(c => c.vaccinationDate1 == null).ToList();
                    return resulte.Count();
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
            return -1;
        }
        public static List<BetweenDates> patientsATMonth()
        {
            try
            {
                using (Corona_DBEntities db = new Corona_DBEntities())
                {
                    System.DateTime now = DateTime.Now;
                    //אלו שחלו החודש
                    var sickAtMonth = db.CoronaDetails_tb.Where(c => c.positiveResultDate !=null && !(c.recoveryDate.Value < now)).ToList();
                    var resulte = from sick in sickAtMonth.DefaultIfEmpty()
                                  select new BetweenDates
                                  {
                                      Start = sick.positiveResultDate,
                                      End = sick.positiveResultDate == null ? null : sick.positiveResultDate
                                  };
                                
                    return resulte.ToList();

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
        public static int[] AtAllDay()
        {
            int[] day = new int[DateTime.Now.Day];
            var allSick = patientsATMonth().ToList();
            int cntAllSick = allSick.Count;
            for (int j = 0; j < day.Length; j++)
            {
                day[j] = cntAllSick;
            }
            //מורידים את אלו שלא היו חולים באותו יום וזה יכול להיות מ2 סיבות:
            //1. אלו שחלו רק באמצע החודש
            var healthyStart = allSick.Where(s => s.Start > new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).OrderByDescending(s=>s.Start).ToList();
            int cntHealthyStart = healthyStart.Count;
            //מהאחרון בחודש מורידים את כל הכמות ואח"כ מורידים בהדרגה לפי המערך
            //כמות ההורדה היא לפי כמה לא חלו עד היום הזה            
            int ind = 0;
            //ההפרש בין כמות החולים שהיה בסוף החודש לכמות שיש ביום הנוכחי
            int less = 1;
            int indBeafore = 0;
            int i = healthyStart[indBeafore].Start.Value.Day;
           
            while (i > 1)
            {
                indBeafore = ind;
                if(healthyStart[ind + 1].Start.Value.Day != healthyStart[ind].Start.Value.Day)
                {
                    ind++;
                    less++;
                }                
                    while (healthyStart[ind + 1].Start.Value.Day == healthyStart[ind].Start.Value.Day)
                    {
                        less++;
                        ind++;
                    }
                
                //סוכם כמה ימים אם מצב זהה שלא היה בהם פחות חולים מהיום הקודם
                int cntSame= healthyStart[ind].Start.Value.Day- healthyStart[indBeafore].Start.Value.Day;
                for (int j = cntSame; j >0 ;j--,i--)
                {
                    day[i-1] -= less;
                }                                   
            }
            //2. אלו שהחלימו באמצע החודש
            return day;
        }


    }
}