#define 입국심사

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersTest
{
    internal class BinarySearch
    {
#if 입국심사
        public long solution(int n, int[] times)
        {
            long answer = 0;

            Array.Sort(times);
            Array.Reverse(times);

            long minTime = 0;
            long maxTime = (long)times[0] * n;

            long mid = 0;
            long count = 0;

            while (minTime != maxTime)
            {
                mid = (minTime + maxTime) / 2;

                count = times.Select(x => mid / x).Sum();

                if (count >= n)
                    maxTime = mid;
                else if (count < n)
                    minTime = mid + 1;
            }

            answer = minTime;

            Console.WriteLine(answer);

            return answer;
        }
#endif
    }
}
