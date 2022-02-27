#define 베스트앨범

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

#if 베스트앨범
        class Info
        {
            public int plays;
            public int number;

            public Info(int p, int n)
            {
                plays = p;
                number = n;
            }
        }

        public int[] solution(string[] genres, int[] plays)
        {
            int[] answer;
            Dictionary<string, List<Info>> genreDic = new Dictionary<string, List<Info>>();
            Dictionary<string, int> genrePlayDic = new Dictionary<string, int>();
            List<int> answerList = new List<int>();

            for(int i = 0; i < genres.Length; i++)
            {
                Info tempInfo = new Info(plays[i], i);

                if(genreDic.ContainsKey(genres[i]))
                {
                    genreDic[genres[i]].Add(tempInfo);
                }
                else
                {
                    List<Info> tempInfoList = new List<Info>();
                    tempInfoList.Add(tempInfo);

                    genreDic.Add(genres[i], tempInfoList);
                }
            }

            foreach(var item in genreDic)
            {
                int totalPlays = 0;

                foreach(Info info in item.Value)
                    totalPlays += info.plays;

                genrePlayDic.Add(item.Key, totalPlays);
            }

            var queryDesc = genrePlayDic.OrderByDescending(x => x.Value);

            foreach(var item in queryDesc)
            {
                genreDic[item.Key].Sort((x, y) => x.number.CompareTo(y.number));
                genreDic[item.Key].Reverse();
                genreDic[item.Key].Sort((x,y) => x.plays.CompareTo(y.plays));
                genreDic[item.Key].Reverse();

                if(genreDic[item.Key].Count > 1)
                {
                    answerList.Add(genreDic[item.Key][0].number);
                    answerList.Add(genreDic[item.Key][1].number);
                }
                else
                    answerList.Add(genreDic[item.Key][0].number);

            }

            answer = answerList.ToArray();

            foreach(int num in answer)
                Console.WriteLine(num);

            return answer;
        }
#endif


    }
}
