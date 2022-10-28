using System;
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
            S--;

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

            List<int> dfsList = new List<int>();

            bool[] visited = new bool[N];
            Stack<int> stack = new Stack<int>();

            visited[S] = true;
            dfsList.Add(S + 1);

            for(int x = N - 1; x >= 0; x--)
            {
                if (adj[S, x] == 1)
                    stack.Push(x);
            }

            while(stack.Count > 0)
            {
                int now = stack.Pop();

                if (visited[now])
                    continue;

                visited[now] = true;
                dfsList.Add(now + 1);

                for (int inner = N - 1; inner >= 0; inner--)
                {
                    if (visited[inner])
                        continue;

                    if (adj[now, inner] == 1)
                        stack.Push(inner);
                }
            }

            foreach (int a in dfsList)
                Console.Write(a + " ");

        }
    }


}
