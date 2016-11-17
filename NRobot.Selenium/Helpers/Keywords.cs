using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace NRobot.Selenium.Helpers
{
    /// <summary>
    /// Class for generic string/number/date helpers not covered by robot framework
    /// </summary>
    class Keywords
    {

        /// <summary>
        /// Extracts a number from a string
        /// </summary>
        public static Double ExtractNumberFromString(string value)
        {
            //check inputs
            if (String.IsNullOrEmpty(value)) throw new Exception("Input string is empty, cannot extract a number");
            //extract
            String allowed = "0123456789.-";
            Int32 length = value.Length;
            String result = "";
            for (int counter=0; counter<length; counter++)
            {
                Char item = value[counter];
                if (allowed.Contains(item))
                {
                    result = result + item;
                }
            }
            return Double.Parse(result);
        }


        /// <summary>
        /// Gets the first matching text of first group of a regular expression
        /// </summary>
        public static string GetRegexpMatches(string input, string expression)
        {
            Regex regex = new Regex(expression, RegexOptions.IgnoreCase);
            Match matches = regex.Match(input);
            var groups = matches.Groups;
            if (groups.Count > 1)
            {
                return groups[1].Captures[0].Value;
            }
            else
            {
                return groups[0].Captures[0].Value;
            }
        }



    }
}
