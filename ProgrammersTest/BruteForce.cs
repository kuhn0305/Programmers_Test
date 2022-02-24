#define 카펫

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersTest
{
    class BruteForce
    {
#if 소수찾기
        public static int solution(string numbers)
        {
            int answer = 0;

            char[] stringCharArr = numbers.ToCharArray();
            List<int> numList = new List<int>();
            List<int> validList = new List<int>();

            foreach(char ch in stringCharArr)
                numList.Add((int)Char.GetNumericValue(ch));

            int min = 0;
            int max = 0;

            numList.Sort();
            min = numList[0];

            Array.Sort(stringCharArr);
            Array.Reverse(stringCharArr);
            string maxString = string.Concat(stringCharArr);
            max = Int32.Parse(maxString);

            Console.WriteLine($"최소값 {min} :: 최대값 {max}");

            for(int index = 0; index <= max; index++)
            {
                if(numList.Contains(index))
                    validList.Add(index);
            }

            foreach(int value in validList)
                Console.Write($"{value}  ");

            return answer;
        }
#endif

#if 카펫
        public static int[] solution(int brown, int yellow)
        {
            int[] answer = new int[2];

            int height = 0;
            int width = 0;
            int yellowArea = 0;

            for(int h = 3; h <= (brown - 2) / 2; h++)
            {
                height = h;
                width = ((brown - (2 * h)) / 2) + 2;

                yellowArea = (height - 2) * (width - 2);

                if(yellowArea == yellow && width >= height)
                {
                    answer[0] = width;
                    answer[1] = height;

                    break;
                }
            }

            Console.WriteLine($"Width :: {answer[0]} / Height :: {answer[1]}");
            Console.WriteLine($"YellowArea :: {yellowArea}");

            return answer;
        }
#endif

    }
}
