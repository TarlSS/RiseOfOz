using System;

namespace RiseOfOz.Logic
{
    /// <summary>
    /// Counts the number of consecutive ones in a binary number
    /// </summary>
    public class BinaryCounter
    {
        public static int ConsecutiveOnes(int value)
        {
            string binary = Convert.ToString(value, 2);
            return ConsecutiveOnes(binary);
        }

        public static int ConsecutiveOnes(string binary)
        {
            int max = 0;
            int currentCount = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '1')
                {
                    currentCount++;
                }
                else
                {
                    if (currentCount > max)
                    {
                        max = currentCount;
                    }
                    currentCount = 0;
                }
            }
            //Gotta end another check for end case
            if(currentCount> max)
            {
                max = currentCount;
            }
            return max;
        }
    }
}
