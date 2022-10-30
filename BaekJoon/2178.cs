using System;
using System.Collections.Generic;
using System.Linq;

namespace BaekJoon
{
    internal class _2178
    {
        private class Pos
        {
            public int y;
            public int x;

            public Pos(int posY, int posX)
            {
                y = posY;
                x = posX;
            }
        }


        public static void Solution()
        {
            string[] lineInfo = Console.ReadLine().Split(' ');

            int sizeY = int.Parse(lineInfo[0]);
            int sizeX = int.Parse(lineInfo[1]);

            int[,] adj = new int[sizeY, sizeX];

            for (int inputY = 0; inputY < sizeY; inputY++)
            {
                char[] mazeInfo = Console.ReadLine().ToArray();

                for (int inputX = 0; inputX < sizeX; inputX++)
                    adj[inputY, inputX] = (int)char.GetNumericValue(mazeInfo[inputX]);
            }

            bool[,] found = new bool[sizeY, sizeX];
            Queue<Pos> queue = new Queue<Pos>();
            int[,] distance = new int[sizeY, sizeX];

            int[] deltaY = new int[] { -1, 0, 1, 0 };
            int[] deltaX = new int[] { 0, -1, 0, 1 };

            found[0, 0] = true;
            queue.Enqueue(new Pos(0, 0));
            distance[0, 0] = 1;

            while (queue.Count > 0)
            {
                Pos nowPos = queue.Dequeue();

                for (int dir = 0; dir < 4; dir++)
                {
                    int nextY = nowPos.y + deltaY[dir];
                    int nextX = nowPos.x + deltaX[dir];

                    if (nextY < 0 || nextY >= sizeY || nextX < 0 || nextX >= sizeX)
                        continue;

                    if (adj[nextY, nextX] == 0)
                        continue;

                    if (found[nextY, nextX])
                        continue;

                    queue.Enqueue(new Pos(nextY, nextX));
                    found[nextY, nextX] = true;
                    distance[nextY, nextX] = distance[nowPos.y, nowPos.x] + 1;
                }
            }

            Console.WriteLine(distance[sizeY -1, sizeX -1]);

        }
    }
}
