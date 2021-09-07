public class YearOf2016
{

    string[] dayArr = new string[7]
    {
        "FRI","SAT","SUN","MON","TUE","WED","THU"
    };

    int[] monthDate = new int[12]
    {
      31,29,31,30,31,30,31,31,30,31,30,31
    };

    public string solution(int a, int b)
    {
        int dateSum = 0;

        for (int index = 0; index < a - 1; index++)
        {
            dateSum += monthDate[index];
        }

        dateSum += b;

        string answer = dayArr[--dateSum % 7];
        return answer;
    }
}