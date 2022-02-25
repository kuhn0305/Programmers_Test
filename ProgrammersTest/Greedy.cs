#define 섬연결하기
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

#if 큰수만들기
        public static string solution(string number, int k)
        {
            string answer = "";

            int stringLength = number.Length;
            int length = stringLength - k;
            int checkLength = length;
            int searchStart = 0;

            char[] numArr = number.ToCharArray();
            List<char> answerList = new List<char>();

            for(int seq = 0; seq < length; seq++)
            {
                char max = '-';
                int maxIndex = 0;

                Console.WriteLine($"{searchStart} :: {stringLength - checkLength + 1}");

                for(int index = searchStart;  index < stringLength - checkLength + 1; index++)
                {
                    if(numArr[index] > max)
                    {
                        maxIndex = index;

                        max = numArr[index];
                    }
                }

                searchStart = maxIndex + 1;
                checkLength--;

                if(max != '-')
                    answerList.Add(max);

                Console.WriteLine(max);
            }

            Console.WriteLine($"과연 길이는? {answerList.Count}");

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(answerList.ToArray());
            answer = stringBuilder.ToString();

            Console.WriteLine(answer);

            return answer;
        }
#endif

#if 섬연결하기

        class Point
        {
            public int start;
            public int dst;
            public int value;

            public bool isUesd;

            public Point(int s, int d, int v)
            {
                start = s;
                dst = d;
                value = v;

                isUesd = false;
            }
        }

        static int GetPartent(int[] set, int x)
        {
            if(set[x] == x)
                return x;
            else
                return set[x] = GetPartent(set, set[x]);
        }

        static void UnionParent(int[] set, int a, int b)
        {
            a = GetPartent(set, a);
            b = GetPartent(set, b);

            if(a < b)
                set[b] = a;
            else
                set[a] = b;
        }

        static bool Find(int[] set, int a, int b)
        {
            a = GetPartent(set, a);
            b = GetPartent(set, b);

            if(a == b)
                return true;
            else
                return false;
        }

        public static int solution(int n, int[,] costs)
        {
            int answer = 0;

            List<Point> points = new List<Point>();

            int[] cycleTable = new int[n];

            for(int index = 0; index < n; index++)
            {
                cycleTable[index] = index;
            }


            for(int i = 0; i < costs.Length / 3; i++)
            {
                int start = 0, dst = 0, value = 0;

                for(int j = 0; j < 3; j++)
                {
                    switch(j)
                    {
                        case 0:
                            start = costs[i, j];
                            break;

                        case 1:
                            dst = costs[i, j];
                            break;

                        case 2:
                            value = costs[i, j];
                            break;
                    }
                }

                points.Add(new Point(start, dst, value));
            }

            points.Sort((x, y) => x.value.CompareTo(y.value));

            foreach(Point point in points)
            {
                if(!Find(cycleTable, point.start, point.dst))
                {
                    answer += point.value;

                    UnionParent(cycleTable, point.start, point.dst);
                }

                foreach(int num in cycleTable)
                    Console.Write($"{num}  ");
                Console.WriteLine();

            }

            Console.WriteLine();
            Console.WriteLine(answer);

            return answer;
        }
#endif
    }
}
