using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NumericStringsAndEnglishWords
{
    static string s1 = "one4seveneight";
    static string s2 = "23four5six7";
    static string s3 = "2three45sixseven";
    static string s4 = "123";

    static Dictionary<string, int> wordsNumPairs = new Dictionary<string, int>()
    {
        {"zero", 0},
        {"one", 1},
        {"two", 2},
        {"three", 3},
        {"four", 4},
        {"five", 5},
        {"six", 6},
        {"seven", 7},
        {"eight", 8},
        {"nine", 9},

    };

    // It's called from the Main Function.
    public static void SolveQuestion()
    {
        ShowAnswer(Solution(s1));
    }

    // Solution
    private static int Solution(string s)
    {
        int answer = 0;

        string input = s;

        char[] sChar = s.ToCharArray();

        foreach(string key in wordsNumPairs.Keys)
        {
            if(s.Contains(key))
            {
                int value = -1;

                if(wordsNumPairs.TryGetValue(key, out value))
                {
                    input = input.Replace(key, value.ToString());
                }
            }
        }

        answer = Int32.Parse(input);

        return answer;
    }

    private static void ShowAnswer(int answer)
    {
        Console.WriteLine(answer);
    }
}