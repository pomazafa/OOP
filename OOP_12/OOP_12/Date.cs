using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_12
{
    public interface InterfaceOfDate
    {

    }
    class Date : InterfaceOfDate
    {
        public int day;
        int month;
        public int year;
        public Date(int d, int m, int y)
        {
            day = d;
            month = m;
            year = y;
        }

        public void GetDate()
        {
            Console.WriteLine(day + "." + month + '.' + year);
        }

        private void GetMonth()
        {
            Console.WriteLine(month);
        }

        public void SetDay(int d)
        {
            day = d;
        }

        public void Test(string lol)
        {
            Console.WriteLine(lol + ' ' + day + "." + month + '.' + year);
        }
    }
}
