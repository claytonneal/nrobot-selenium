using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace NRobot.Selenium.Helpers
{
    /// <summary>
    /// Class for generic string/number/date helpers not covered by robot framework
    /// </summary>
    public class Keywords
    {

        /// <summary>
        /// Extracts a number from a string
        /// </summary>
        public static double ExtractNumberFromString(string value)
        {
            //check inputs
            if (string.IsNullOrEmpty(value)) throw new Exception("Input string is empty, cannot extract a number");
            //extract
            string allowed = "0123456789.-";
            int length = value.Length;
            string result = string.Empty;
            for (int counter = 0; counter < length; counter++)
            {
                char item = value[counter];
                if (allowed.Contains(item))
                {
                    result = result + item;
                }
            }
            return double.Parse(result);
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
