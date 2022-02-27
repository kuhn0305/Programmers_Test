#define 위장

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersTest
{
    class Hash
    {
#if 위장
        public int solution(string[,] clothes)
        {
            int answer = 1;

            Dictionary<string, List<string>> clothDic = new Dictionary<string, List<string>>();

            for(int i = 0; i < clothes.Length / 2; i++)
            {
                string key = string.Empty;
                string value = string.Empty;

                for(int j = 0; j < 2; j++)
                {
                    if(j == 1)
                        key = clothes[i, j];
                    else if(j == 0)
                        value = clothes[i, j];
                }

                if(clothDic.ContainsKey(key))
                    clothDic[key].Add(value);
                else
                {
                    List<string> valueList = new List<string>();
                    valueList.Add(value);

                    clothDic.Add(key, valueList);
                }
            }

            foreach(var item in clothDic)
                answer *= (item.Value.Count + 1);

            answer--;

            Console.WriteLine(answer);

            return answer;
        }
#endif
    }
}
