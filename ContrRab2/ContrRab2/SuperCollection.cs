using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContrRab2
{
    public class SuperCollection
    {
        public List<string> list_of_string;
        public SuperCollection()
        {
            list_of_string = new List<string>();
        }

        public bool Add<T>(T elem)
        {
            list_of_string.Add(Convert.ToString(elem));
            return true;
        }
    }
}
