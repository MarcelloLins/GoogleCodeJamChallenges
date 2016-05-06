using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenges.TwoNumbersSum
{
    class TwoNumbersSum
    {
        /**
         *  Implementation: 
         *   - Two nested loops
         *   - The second loop starts one element ahead of the first one, to lower the number of iterations and avoid redundancy
         *   - I and J keeps track of both indexes used to do the sum
         *   - Time Complexity: O(n^2)
         */

        /// <summary>
        /// Given a source array of integers, returns the indexes of the two
        /// numbers that sum the target
        /// </summary>
        /// <param name="nums">Integers array</param>
        /// <param name="target">The target number</param>
        /// <returns>Indexes of the two numbers that sum the target received</returns>
        public static int[] TwoSum (int[] nums, int target)
        {
            int[] answer = new int[2];

            // Two Nested Loops - Cost: O(n^2)
            for (int i = 0; i <= nums.Length - 2; i++)
            {
                for (int j = i + 1; j <= nums.Length - 1; j++)
                {
                    int numA = nums[i];
                    int numB = nums[j];

                    if (numA + numB == target)
                    {
                        answer[0] = i;
                        answer[1] = j;
                        return answer;
                    }
                }
            }

            return answer;
        }

        /**
         *  Implementation: 
         *   - One Loop Only
         *   - For each element, check whether it's complement is on the Dictionary already
         *   - If it is, returns the index of the current element + the index of it's complement
         *   - Time Complexity: O(n)
         */

        /// <summary>
        /// Given a source array of integers, returns the indexes of the two
        /// numbers that sum the target
        /// </summary>
        /// <param name="nums">Integers array</param>
        /// <param name="target">The target number</param>
        /// <returns>Indexes of the two numbers that sum the target received</returns>
        public static int[] TwoSumWithDictionary (int[] nums, int target)
        {
            Dictionary<int, int> numberAndIndex = new Dictionary<int, int> ();

            // Single Iteration building the dictionary of numbers and their indexes
            // Time Complexity: O(n)
            for (int idx = 0; idx < nums.Length; idx++ )
            {
                // Calculating Complement of the current number
                int complement = target - nums[idx];

                // Is the current Complement already on the dictionary ?
                if(numberAndIndex.ContainsKey(complement))
                {
                    // We found the solution
                    return new int[2] {numberAndIndex[complement], idx };
                }

                // Adding the current number to the dictionary
                numberAndIndex.Add (numberAndIndex[idx], idx);
            }

            throw new Exception ("Could not find two numbers that sum up to the target");
        }
    }
}
