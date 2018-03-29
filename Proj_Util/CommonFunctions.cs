using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.UITest;

namespace Proj_Utils
{
    public class CommonFunctions
    {
        public static Int32 stepCtr = 1;
        public static Boolean isReady;
        public static String AutoUser = System.Windows.Forms.SystemInformation.UserName.ToString();

        public static DateTime GetDateFromString(String date)
        {
            DateTime dt12 = DateTime.Now.Date;
            try
            {
                Regex rgx = new Regex(@"\d{2}/\d{2}/\d{4}");
                Match m = rgx.Match(date);

                if (DateTime.TryParseExact(m.Value, "MM/dd/yyyy", null, DateTimeStyles.None, out dt12))
                    return dt12;
                else return dt12;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string CaptureScreen(IApp app)
        {
            String fileName = @"C:\ExtentReport\Snapshot_" + DateTime.Now.ToString("MM - dd - yyyy HH - mm - ss") + ".png";
            app.Screenshot(fileName).CopyTo(fileName);
            return fileName;
        }
    }
}
