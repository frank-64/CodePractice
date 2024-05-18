using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice
{
    public class LeetCodePractice
    {
        public static Dictionary<int, string[]> phoneNumberLetters = new Dictionary<int, string[]> {
            { 2, new string[] { "a", "b", "c" } },
            { 3, new string[] { "d", "e", "f" } },
            { 4, new string[] { "g", "h", "i" } },
            { 5, new string[] { "j", "k", "l" } },
            { 6, new string[] { "m", "n", "o" } },
            { 7, new string[] { "p", "q", "r", "s" } },
            { 8, new string[] { "t", "u", "v" } },
            { 9, new string[] { "w", "x", "y", "z" } }
        };


        // https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
        public static IList<string> LetterCombinationsOfPhoneNumber(string digits)
        {
            if (string.IsNullOrEmpty(digits))
                return new List<string>();

            List<int> digitInts = digits.Select(digit => digit - '0').ToList();

            // Initialize the result list with an empty string to start the combinations
            List<string> result = new List<string> { "" };

            foreach (int digit in digitInts)
            {
                if (!phoneNumberLetters.ContainsKey(digit))
                    continue;

                // Get the corresponding string array for the current digit
                string[] letters = phoneNumberLetters[digit];

                // Create a temporary list to store the new combinations
                List<string> tempList = new List<string>();

                foreach (string prefix in result)
                {
                    foreach (string letter in letters)
                    {
                        tempList.Add(prefix + letter);
                    }
                }

                // Update the result list with the new combinations
                result = tempList;
            }

            return result;
        }
    }
}
