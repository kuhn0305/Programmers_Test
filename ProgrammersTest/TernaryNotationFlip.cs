using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TernaryNotationFlip
{
    // It's called from the Main Function.
    public static void SolveQuestion()
    {
        ShowAnswer(Solution(45));
    }

    // Solution
    private static int Solution(int n)
    {
        int answer = 0;

        int targetNum = n;
        int divider = 3;

        Stack<int> answerStack = new Stack<int>();
        int result = 0;


        while (targetNum > 0)
        {
            result = targetNum % divider;

            if (targetNum >= 3)
                targetNum /= divider;
            else
                targetNum = 0;

            answerStack.Push(result);
        }

        int stackCount = 0;
        int pow;

        while (answerStack.Count > 0)
        {
            //Console.WriteLine(answerStack.Pop());

            pow = (int)Math.Pow(divider, stackCount);
            answer += answerStack.Pop() * pow;

            stackCount++;
        }

        return answer;
    }

    private static void ShowAnswer(int answer)
    {
        Console.WriteLine(answer);
    }
}
