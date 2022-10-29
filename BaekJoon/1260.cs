using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaekJoon
{
    static class _1260
    {
        // DFS와 BFS
        public static void Solution()
        {
            string[] inputString = Console.ReadLine().Split(' ');

            short N = short.Parse(inputString[0]);
            short M = short.Parse(inputString[1]);
            short S = short.Parse(inputString[2]);
            S -= 1;

            int[,] adj = new int[N, N];

            for (int count = 0; count < M; count++)
            {
                string[] edgeInput = Console.ReadLine().Split(' ');

                short y = short.Parse(edgeInput[0]);
                short x = short.Parse(edgeInput[1]);

                adj[y - 1, x - 1] = 1;
                adj[x - 1, y - 1] = 1;
            }

            // DFS 구현
            List<int> answerList = new List<int>();

            bool[] visited = new bool[N];
            Stack<int> stack = new Stack<int>();

            stack.Push(S);

            while(stack.Count > 0)
            {
                int now = stack.Pop();

                if (visited[now])
                    continue;

                visited[now] = true;
                answerList.Add(now + 1);

                for (int inner = N - 1; inner >= 0; inner--)
                {
                    if (visited[inner])
                        continue;

                    if (adj[now, inner] == 1)
                        stack.Push(inner);
                }
            }

            foreach (int a in answerList)
                Console.Write($"{a} ");

            Console.WriteLine();

            // BFS 구현
            answerList.Clear();

            visited = new bool[N];
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(S);

            while(queue.Count > 0)
            {
                int now = queue.Dequeue();

                if (visited[now])
                    continue;

                visited[now] = true;
                answerList.Add(now + 1);

                for(int inner = 0; inner < N; inner++)
                {
                    if (visited[inner])
                        continue;

                    if (adj[now,inner] == 1)
                        queue.Enqueue(inner);
                }
            }

            foreach (int a in answerList)
                Console.Write($"{a} ");
        }
    }


}
