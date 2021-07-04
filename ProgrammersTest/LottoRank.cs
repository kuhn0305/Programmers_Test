using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LottoRank
{
    #region TestCase
    private static int[] lottos1 = new int[]
{
        44, 1, 0, 0, 31, 25
};

    private static int[] lottos2 = new int[]
    {
        0, 0, 0, 0
    };

    private static int[] lottos3 = new int[]
    {
        45, 4, 35, 20, 3, 9
    };

    private static int[] win_nums1 = new int[]
    {
        31, 10, 45, 1, 6, 19
    };

    private static int[] win_nums2 = new int[]
    {
        38, 19, 20, 40, 15, 25
    };

    private static int[] win_nums3 = new int[]
    {
        20, 9, 3, 45, 4, 35
    };
    #endregion

    // It's called from the Main Function.
    public static void SolveQuestion()
    {
        ShowAnswer(Solution(lottos1, win_nums1));
    }

    private static int[] Solution(int[] lottos, int[] win_nums)
    {
        int[] answer = new int[2];

        int matchCount = 0;
        int jokerCount = 0;

        List<int> winNumList = new List<int>(win_nums);

        for (int index = 0; index < lottos.Length; index++)
        {
            if (winNumList.Contains(lottos[index]))
            {
                matchCount++;
            }
            else if (lottos[index] == 0)
            {
                jokerCount++;
            }
        }

        answer[0] = CalculateRank(matchCount + jokerCount);
        answer[1] = CalculateRank(matchCount);

        return answer;
    }

    private static int CalculateRank(int score)
    {
        if ((7 - score) < 6)
            return (7 - score);
        else
            return 6;
    }

    private static void ShowAnswer(int[] answer)
    {
        foreach(int num in answer)
        {
            Console.Write($"{num} ");
        }
    }
}

