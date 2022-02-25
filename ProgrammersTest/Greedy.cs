#define 조이스틱
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersTest
{
    class Greedy
    {
#if 조이스틱

        public static int solution(string name)
        {
            int answer = 0;
            int n = name.Length;
            int leftOrRight = name.Length - 1;

            for(int i = 0; i < n; i++)
            {
                int next = i + 1;
                char target = name[i];

                if(target <= 'N')
                    answer += target - 'A';
                else
                    answer += 'Z' - target + 1;
                Console.WriteLine();
                Console.WriteLine($"현재 시점 {i} / 현재 Answer {answer}");

                while(next < n && name[next] == 'A')
                    next++;

                Console.WriteLine($"반복문 이후 Next {next}");

                leftOrRight = Math.Min(leftOrRight, i + n - next + Math.Min(i, n - next));

                Console.WriteLine($"@@@@ {i} + {n - next} + {Math.Min(i, n - next)} = { i + n - next + Math.Min(i, n - next)}");

                // i는 현재 위치까지의 이동거리
                // n-next는 가장 먼저 마주한 A의 연속 이후의 이동거리
                // Math.Min(i, n-next)는 A의 연속 좌측 우측으로 뒤돌아가는 비용을 계산한 것

                Console.WriteLine($"Left Or Right {leftOrRight}");
            }

            answer += leftOrRight;

            return answer;
        }

#endif
    }
}
