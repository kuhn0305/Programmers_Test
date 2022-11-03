#define 아이템줍기

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

#if 네트워크

        public int solution(int n, int[,] computers)
        {
            int answer = 0;
            int[] table = new int[n];

            for(int index = 0; index < table.Length; index++)
                table[index] = index;

            for(int i = 0; i < computers.Length / n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    // i번 PC와 j번 PC가 연결되어 있을 경우
                    if(computers[i, j] == 1)
                    {
                        if(table[i] < table[j])
                            table[j] = table[i];
                        else
                            table[i] = table[j];

                        foreach(int value in table)
                            Console.Write($"{value}  ");
                        Console.WriteLine();
                    }
                }
            }

            for(int a = 0; a < table.Length; a++)
            {
                if(a == table[a])
                    answer++;
            }

            Console.WriteLine(answer);
            return answer;
        }
#endif

#if 단어변환

        bool[] visited;
        int stringLength;

        string answerTarget;
        int answer;

        bool isTargetInArr;

        public int solution(string begin, string target, string[] words)
        {
            answer = 0;
            visited = new bool[words.Length];

            Array.Fill(visited, false);

            stringLength = begin.Length;
            answerTarget = target;

            if(words.Contains(target))
                isTargetInArr = true;
            else
                isTargetInArr = false;  

            Search(words, 0, begin);

            Console.WriteLine(answer);

            return answer;
        }

        void Search(string[] words, int index, string current)
        {
            // 이 Search를 한번 할 때 기능

            if(Array.TrueForAll(visited ,x => x == true))
            {
                Console.WriteLine("모든 노드를 방문했습니다.");

                if(current != answerTarget)
                    answer = 0;

                return;
            }
  
            if(current == answerTarget)
            {
                Console.WriteLine( $"정답: {current}");
                return;
            }

            // 타겟이 Array안에 포함되어있으면 먼저 검사를 진행한다.
            if(isTargetInArr)
            {
                int diffLetter = 0;

                for(int i = 0; i < stringLength; i++)
                {
                    if(current[i] != answerTarget[i])
                    {
                        diffLetter++;
                    }
                }

                // 글자가 1개만 다르면 현재 단어로 교체
                if(diffLetter == 1)
                {
                    current = answerTarget;
                    Console.WriteLine($"★ {current}");
                    answer++;

                    return;
                }
            }

            // 현재 노드가 방문되었는지 확인하고 방문 체크
            if(visited[index] == false)
            {
                visited[index] = true;

                int diffLetter = 0;

                diffLetter = 0;

                // 글자 다른것 체크
                for(int i = 0; i < stringLength; i++)
                {
                    if(words[index][i] != current[i])
                    {
                        diffLetter++;
                    }
                }

                // 글자가 1개만 다르면 현재 단어로 교체
                if(diffLetter == 1)
                {
                    current = words[index];
                    Console.WriteLine($"☆ {current}");
                    answer++;
                }

                Search(words, index + 1, current);
            }
        }
#endif

#if 여행경로

        class Point
        {
            public string dep;
            public string dst;
            public bool visited;

            public Point(string dp, string dt)
            {
                dep = dp;
                dst = dt;
            }
        }

        public List<string> answerList;
        bool isValid = false;

        public string[] solution(string[,] tickets)
        {
            string[] answer = new string[] { };
            List<Point> points = new List<Point>();
            answerList = new List<string>();

            for(int i = 0; i < tickets.Length / 2; i++)
            {
                string dep = string.Empty;
                string dst = string.Empty;

                for(int j = 0; j < 2; j++)
                {
                    if(j == 0)
                        dep = tickets[i, j];
                    else if(j == 1)
                        dst = tickets[i, j];
                }
                points.Add(new Point(dep, dst));
            }

            Search(points, "ICN");


            foreach(string aaa in answerList)
                Console.Write($"{aaa}  ");

            answer = answerList.ToArray();

            return answer;
        }

        void Search(List<Point> points, string currentDep)
        {
            isValid = false; 

             Console.WriteLine($"현재 출발지 :: {currentDep}");

            if(answerList.Count == points.Count)
            {
                answerList.Add(currentDep);

                Console.WriteLine("경로 방문 완료!");
                isValid = true;

                return;
            }

            answerList.Add(currentDep);

            // 목적지 선정 (알파벳 순으로 정렬)
            List<Point> tempPoints = new List<Point>();
            tempPoints = points.FindAll(x => x.dep == currentDep);

            var sortedPoints =
                from point in tempPoints
                orderby point.dst
                select point;

            // 목적지 선정 완료
            Point nextPoint = null;

            foreach(Point targetPoint in sortedPoints)
            {
                // 방문하지 않음
                if(targetPoint.visited  == false)
                {
                    targetPoint.visited = true;
                    nextPoint = targetPoint;

                    Search(points, nextPoint.dst);

                    if(isValid)
                        break;
                    else
                    {
                        Console.WriteLine($"경로취소 :: {targetPoint.dst}");

                        answerList.RemoveAt(answerList.Count - 1);
                        targetPoint.visited = false;
                    }
                }
            }
        }
#endif

#if 아이템줍기
        public int solution(int[,] rectangle, int characterX, int characterY, int itemX, int itemY)
        {
            int answer = 0;

            int[,] adj = new int[50, 50];

            int leftX = 0;
            int leftY = 0;
            int rightX = 0;
            int rightY = 0;

            int[] rectPos = new int[] {  };

            for (int rect = 0; rect < rectangle.GetLength(0); rect++)
            {
                for (int recInfo = 0; recInfo < 4; recInfo++)
                {
                    leftX = rectangle[rect, recInfo];
                }
            }



            return answer;
        }
#endif
    }
}
