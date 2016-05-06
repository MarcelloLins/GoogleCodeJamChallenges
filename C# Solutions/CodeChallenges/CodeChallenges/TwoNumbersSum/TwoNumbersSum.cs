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

            // Two Nested Loops - Cost: O(n Log(n))
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
    }
}
