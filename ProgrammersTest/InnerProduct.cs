using System;

class InnerProduct
{
    #region TestCase
    private static int[] a1 = new int[]
{
        1,2,3,4
};

    private static int[] b1 = new int[]
    {
        -3, -1, 0, 2
    };

    private static int[] a2 = new int[]
    {
        -1, 0, 1
    };

    private static int[] b2 = new int[]
    {
        1,0,-1
    };
    #endregion

    // It's called from the Main Function.
    public static void SolveQuestion()
    {
        ShowAnswer(Solution(a2, b2));
    }

    // Solution
    private static int Solution(int[] a, int[] b)
    {
        int answer = 0;

        for (int i = 0; i < a.Length; i++)
        {
            answer += a[i] * b[i];
        }

        return answer;
    }

    private static void ShowAnswer(int answer)
    {
        Console.WriteLine(answer);
    }
}

