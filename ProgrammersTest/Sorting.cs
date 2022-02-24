#define H_Index
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersTest
{
    class Sorting
    {
#if K번째수
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
#endif

#if 가장큰수
    public static string solution(int[] numbers) {
        
        Array.Sort(numbers, (x,y)=>{
            string XY = x.ToString() + y.ToString();
            string YX = y.ToString() + x.ToString();
            return YX.CompareTo(XY);
        });
        
        if(numbers.Where(x => x == 0).Count() == numbers.Length)
            return "0";
        else
            return string.Join("",numbers);
    }
#endif

#if H_Index
        public static int solution(int[] citations)
        {
            int h = 0;
            List<int> citationList = new List<int>(citations);

            citationList.Sort();

            for(int index = citationList.Count - 1; index >= 0; index--)
            {
                h++;

                if(h > citationList[index])
                {
                    h--;
                    break;
                }
            }
            Console.WriteLine(h);

            return h;
        }
#endif
    }
}
