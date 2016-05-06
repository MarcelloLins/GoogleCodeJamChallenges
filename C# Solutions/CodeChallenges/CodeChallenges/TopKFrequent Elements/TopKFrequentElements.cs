using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenges.TopKFrequent_Elements
{
    class TopKFrequentElements
    {
        /**
         *  Implementation: 
         *   - Iterates through the array building a dictionary of frequencies of each found integer
         *   - Sorts the Dictionary in Reverse order
         *   - Take the first K elements of the sorted collection
         */

        /// <summary>
        /// Returns the top K elements from the original array, sorted by their frequency in the array itself.
        /// </summary>
        /// <param name="nums">Array of numbers to be analized</param>
        /// <param name="k">Slice Size</param>
        /// <returns>List of the top "K" elements from the original array</returns>
        public IList<int> TopKFrequent (int[] nums, int k)
        {
            Dictionary<int, int> frequencies = new Dictionary<int, int> ();

            // Grouping Frequencies in a Dictionary - COST O(n)
            foreach(int n in nums)
            {
                if (frequencies.ContainsKey(n))
                {
                    frequencies[n]++;
                }
                else
                {
                    frequencies.Add (n, 1);
                }
            }

            // Sorting the Dictionary and Slicing the Top K - COST O(n Log(n)) + K = O(n Log(n))
            return frequencies.OrderByDescending (t => t.Value).Select(t => t.Key).Take(k).ToList();
        }
    }
}
