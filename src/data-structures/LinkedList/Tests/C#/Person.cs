using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListTest
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static int Comparator(Person p1, Person p2)
        {
            return String.Compare(p1.FirstName + ":" + p1.LastName, p2.FirstName + ":" + p2.LastName);
        }
    }
}
