using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenges
{
    class ReverseVowels
    {
        /**
        *  Implementation: 
        *   - Sets two pointers, at the end and at the start of the string
        *   - Moves the left-most pointer to the right until it finds a vowel
        *   - If a Vowel is found, moves the other pointer to the left, until a vowel is found
         *  - Once both vowels are found, swaps them
         * 
         * 
         * Notes: 
         *     - An integer is kept to keep track whether the two vowels were found so the swap routine can trigger.
         *     - C# Strings are immutable, hence, I had to work with Char[] instead to do the swapping of the vowels
         *     - There's an extra routine I wrote to check whether a character is a Vowel or not.         
         *     
         *     - Time Complexity: O(n)
         */


        /// <summary>
        /// Given the string received, it reverses each vowel of the string with the oposite one
        /// on the word.
        /// 
        /// E.G: HelloL   => HolleL
        ///      Hugs     => Hugs
        ///      Marcello => Morcella
        /// </summary>
        /// <param name="s">The word</param>
        /// <returns>Same string with the vowels reversed</returns>
        public static string ReverseVowelsMethod (string s)
        {
            // Indexes / Pointers
            int lowerIdx = 0;
            int upperIdx = s.Count () - 1;

            // Step Value (+1 to move the pointer from Left to Right, -1 to move the pointer from Right to Left)
            int stepValue = 1;

            // Basic Sanity check for extraordinary cases
            if (String.IsNullOrWhiteSpace (s))
            {
                return String.Empty;
            }

            if (s.Count () == 1)
            {
                return s;
            }

            // Work-Variables
            char lwrCharacter, upprCharacter, tmpVowel;
            int vowelsFound = 0;

            // Working with Char Arrays, that are mutable unlike strings in C#
            var word = s.ToCharArray ();

            // Stop Condition: While the pointers have not crossed yet
            while (lowerIdx < upperIdx)
            {
                // Should we move the left most pointer forward ?
                if (stepValue == 1)
                {
                    lwrCharacter = word[lowerIdx];

                    if (IsVowel (lwrCharacter))
                    {
                        stepValue = -1;
                        vowelsFound++;
                    }
                    else
                    {
                        lowerIdx += stepValue;
                    }
                }

                // Should we move the right most pointer backward ?
                if (stepValue == -1)
                {
                    upprCharacter = word[upperIdx];
                    if (IsVowel (upprCharacter))
                    {
                        stepValue = 1;
                        vowelsFound++;
                    }
                    else
                    {
                        upperIdx += stepValue;
                    }
                }

                // Swaping Vowels
                if (vowelsFound == 2)
                {
                    tmpVowel = word[lowerIdx];
                    word[lowerIdx] = word[upperIdx];
                    word[upperIdx] = tmpVowel;
                    vowelsFound = 0;

                    upperIdx--;
                    lowerIdx++;
                }
            }

            // Building string out of Char[]
            return new string (word);
        }

        private static bool IsVowel (char c)
        {
            return new[] { 'a', 'e', 'i', 'o', 'u' }.Contains (char.ToLower (c));
        }
    }
}
