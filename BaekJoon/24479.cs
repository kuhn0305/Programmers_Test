using System;

namespace BaekJoon
{
    class _24479
    {
        int N = 0;
        int M = 0;
        int R = 0;

        bool[] found = new bool[0];
        int[,] adj = new int[0,0];
        public void Solution()
        {
            string[] vertexInfo = Console.ReadLine().Split(' ');

            N = int.Parse(vertexInfo[0]);
            M = int.Parse(vertexInfo[1]);
            R = int.Parse(vertexInfo[2]);

            adj = new int[N, N];

            for(int count = 0; count < M; count++)
            {
                string[] vertex = Console.ReadLine().Split(' ');

                int posY = int.Parse(vertex[0]);
                int posX = int.Parse(vertex[1]);

                adj[posY, posX] = 1;
            }

            DFS(R);

            for(int node = 0; node < N; node++)
            {
                if (found[node] == false)
                    Console.WriteLine(0);
            }

        }

        public void DFS(int now)
        {
            found[now] = true;

            Console.WriteLine(now);

            for(int next = 0; next < N; next++)
            {
                if (adj[now, next] == 0)
                    continue;

                if (found[next])
                    continue;

                DFS(next);
            }
        }
    }
}
