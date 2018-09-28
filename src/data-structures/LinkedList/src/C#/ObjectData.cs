using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.LinkedList
{
    public static class ObjectData<T>
    {
        public static bool IsEmpty(T value)
        {
            if( typeof(T).IsValueType && value.Equals(default(T)))
            {
                return true;
            }

            if (!typeof(T).IsValueType && value == null)
            {
                return true;
            }

            return false;
        }
    }
}
