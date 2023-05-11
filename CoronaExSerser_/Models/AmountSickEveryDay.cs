using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace שרת_שנה_ג.Models
{
    public class AmountSickEveryDay
    {

        //מחלקה זו נועדה לחשב את כמות החולים בכל יום מהחודש האחרון
        //זה אמור להעשות באמצעות שטילת הנתונים מהדתא בייס (עוד לא הספקתי לעשות זאת
        //זמן ריצה של הפונקציה הוא o(nlogn)
        //האלגוריתם מתייחס למערכים של התאריכים כאל מערך מצביעים, כל תאריך הוא מצביע לתא שהאינדקס שלו שווה לתאריך
        //האלגוריתם מחלק את החולים ל4 קבוצות:
        //1. אלו שהיו חולים כל החודש
        //2.אלו שהיו חולים רק בתחלית החודש
        //3. אלו שהיו חולים מאמצע החודש אז הסוף
        //4. אלו שחלו באמצע החודש והבריאו באמצע החודש
        //כל קבוצה היא במערך נפרד שנלחת לפונקציה startOrEnd()
        //אחרי שהיא חוזרת מבצעים עליה חישובים
        //הערה: אלו שהיו חולים כל החודש לא נשלחים לפונקציה הנ"ל אלא מחושבים כשארית של שאר הקבוצות מסכום החולים בחודש הכללי
        public static int[] startOrEnd(int[] list, int now)
        {
            int[] day = new int[now];
            int cnt = 0;
            for (int i = 0; i < list.Length; i++)
            {
                day[list[i]] = ++cnt;
            }
            for (int i = list[0] + 1; i < day.Length; i++)
            {
                if (day[i] == 0)
                    day[i] = day[i - 1];
            }
            return day;
        }
        public static int[] returnDetails(String[] args)
        {
            int now = 11 + 1;
            //כל החולים שחלו החודש הזה
            int sumAll = 16;
            //אלו שהבריאו באמצע החודש

            int[] sickStart = { 2, 5, 6, 9 };
            //אלו שקיבלו תשובה חיובית באמצע החודש
            int[] sickEnd = { 2, 5, 6 };
            //אלו שקיבלו תשובה חיובית באמצע החודש והחלימו באמצע החודש
            int[] sickBetweenS = { 2, 4, 4, 5, 6, 7, 9 };
            int[] sickBetweenE = { 8, 7, 9, 8, 8, 8, 10 };
            //התשובה היא על הימים עד היום הנוכחי בהנחה שלא ניתן לדעת מתי יבריאו אלו שחולים עכשיו ולכן א"א לספור כמה יהיו חולים בעתיד
            int[] cntMiddle = sickBetweenS.Length == 0 ? new int[now] : sickMiddle(sickBetweenS, sickBetweenE, now);
            int[] resulte = new int[now];
            int[] cntStart = sickStart.Length == 0 ? new int[now] : startOrEnd(sickStart, now);
            int[] cntEnd = sickEnd.Length == 0 ? new int[now] : startOrEnd(sickEnd, now);
            //אלו שחולים כל החודש-הסכום הכולל פחות 3 הקבוצות: התחלה, סוף והביניים
            int sickAllTime = sumAll - sickEnd.Length - sickBetweenS.Length - sickStart.Length;
            for (int i = 1; i < cntStart.Length; i++)
            {
                cntStart[i] = sickStart.Length - cntStart[i];
            }
            for (int i = 1; i < resulte.Length; i++)
            {
                //התוצאה=בכל יום מוסיפים את אלו שהיו חולים כל החודש,
                // את אלו שחלו עד היום הזה,
                // בקבוצת אלו שהבריאו באמצע החודש מחשבים כל הקבוצה חולים פחות אלו שהבריאו,
                //  ואת קבומת הביניים מוספים כמו שהיא
                resulte[i] = sickAllTime + cntStart[i] + cntEnd[i] + cntMiddle[i];              
            }
            return resulte;
        }

        private static int[] sickMiddle(int[] start, int[] end, int now)
        {
            int[] resulte = new int[now];
            Array.Sort(end);
            int[] cntStart = start.Length == 0 ? new int[now] : startOrEnd(start, now);
            int[] cntEnd = end.Length == 0 ? new int[now] : startOrEnd(end, now);
            for (int i = 0; i < now; i++)
            {
                resulte[i] = cntStart[i] - cntEnd[i];
            }
            resulte[now - 1] = 0;
            return resulte;
        }
    }
}