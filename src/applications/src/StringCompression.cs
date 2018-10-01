using System;
using System.Collections.Generic;
using System.Linq;

namespace application
{
    /// <summary>
    /// Implement a method to perform basic string compression using the counts of repeated characters.
    /// example : string aabcccccaaa becomes a2b1c5a3.
    /// </summary>
    public static class StringCompression
    {
        public static string GetCompressedString( string data)
        {
            if( string.IsNullOrEmpty(data))
            {
                return data;
            }

            var charArray = data.ToCharArray();
            var formattedString = new List<string>();
            var index = 0;
            var characterCount = 0;
            formattedString.Add(charArray[0] + (characterCount + 1).ToString());
            var characters = charArray.Skip(1);
            foreach ( var c in characters)
            {
                if( formattedString[index].Equals(c + (characterCount + 1).ToString()))
                {
                    characterCount++;
                    formattedString[index] = c + (characterCount + 1).ToString();
                }
                else
                {
                    characterCount = 0;
                    index++;
                    formattedString.Add(c + (characterCount + 1).ToString());
                }                
            }

            return string.Join(String.Empty, formattedString);
        }
    }
}
