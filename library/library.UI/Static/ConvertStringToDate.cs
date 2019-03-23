using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library.UI.Static
{
    public static class ConvertStringToDate
    {
        public static void ConvertDate(string date,ref DateTime? release)
        {
            try
            {
                if (date != "")
                {
                    string month = date.Substring(0, 2);
                    string day = date.Substring(3, 2);
                    string year = date.Substring(6, 4);

                    int month1 = Convert.ToInt32(month);
                    int day1 = Convert.ToInt32(day);
                    int year1 = Convert.ToInt32(year);

                    DateTime release2 = new DateTime(year1, month1, day1);
                    release = (DateTime)release2;
                }
                else { return; }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Please enter date in format mm / dd / yyyy");
                Application.Restart();
            }
        }
    }
}
