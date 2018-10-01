using System;
using System.Collections.Generic;

namespace application
{
    /// <summary>
    /// Problem Statement : Given two strings, write a method to decide if one is a permutation of the other.
    /// </summary>
    public static class Permutation
    {
        public static bool IsPermutedString( string source, string target)
        {
            if( string.IsNullOrEmpty(source))
            {
                return false;
            }

            if( source.Length != target.Length)
            {
                return false;
            }

            var items = source.ToCharArray();
            var permutedStrings = new List<string>();
            GetPermutations(items, 0, items.Length - 1, permutedStrings);
            return permutedStrings.Contains(target);
        }

        public static void GetPermutations(char[] items, int recursion, int length, List<string> data)
        {
            if(recursion == length)
            {
                data.Add(new string(items));
            }
            else
            {
                for (int index = recursion; index <= length; index++)
                {
                    Swap(ref items[recursion], ref items[index]);
                    GetPermutations(items, recursion + 1, length, data);
                    Swap(ref items[recursion], ref items[index]);
                }
            }            
        }

        private static void Swap(ref char a , ref char b)
        {
            char tmp = a;
            a = b;
            b = tmp;
        }       
    }
}
