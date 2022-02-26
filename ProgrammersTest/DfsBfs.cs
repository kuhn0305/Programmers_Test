#define 타겟넘버

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersTest
{
    class DfsBfs
    {
#if 타겟넘버
        int targetNum = 0;
        int answer = 0;

        public int solution(int[] numbers, int target)
        {
            targetNum = target;

            DFS(numbers, 0, 0);

            Console.WriteLine(answer);

            return answer;
        }

        public void DFS(int[] numbers, int index, int sum)
        {
            if(numbers.Length == index)
            {
                if(sum == targetNum)
                    answer++;
            }
            else
            {
                DFS(numbers, index + 1, sum + numbers[index]);
                DFS(numbers, index + 1, sum - numbers[index]);
            }
        }
#endif
    }
}
