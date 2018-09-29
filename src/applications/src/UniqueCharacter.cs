using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    /// <summary>
    /// This class provide functionality to determine unique characters in a string.
    /// Problem Statement : Implement a logic to return unique characters in a string.
    /// </summary>
    public static class UniqueCharacter
    {
        public static string GetUniqueCharacters( string testData)
        {
            if( testData == null)
            {
                return null;
            }

            if( testData.Length == 0)
            {
                return String.Empty;
            }

            List<char> data = new List<char>();
            foreach( var c in testData)
            {
                if (!data.Contains(c))
                {
                    data.Add(c);
                }
            }

            return new String(data.ToArray());
        }
    }
}
