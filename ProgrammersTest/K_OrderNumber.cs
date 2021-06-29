using System;
using System.Collections.Generic;

class K_OrderNumber
{
    #region TestCase

    private static int[] array = new int[]
{
        1,5,2,6,3,7,4
};

    private static int[,] commands = new int[,]
    {
        {2,5,3}, {4,4,1}, {1,7,3}
    };

    #endregion

    // It's called from the Main Function.
    public static void SolveQuestion()
    {
        ShowAnswer(Solution(array, commands));
    }

    // Solution
    private static int[] Solution(int[] array, int[,] commands)
    {
        int[] answer = new int[commands.Length / 3];

        for (int c = 0; c < commands.Length / 3; c++)
        {
            List<int> temp = new List<int>();

            for (int i = commands[c, 0] - 1; i <= commands[c, 1] - 1; i++)
            {
                temp.Add(array[i]);
            }

            temp.Sort();

            answer[c] = temp[commands[c, 2] - 1];
        }

        return answer;
    }

    private static void ShowAnswer(int[] answer)
    {
        foreach (int num in answer)
        {
            Console.Write($"{num} ");
        }
    }
}
