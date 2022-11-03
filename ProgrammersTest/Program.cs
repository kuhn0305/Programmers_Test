using System;
using ProgrammersTest;

class Program
{
    static void Main(string[] args)
    {
        // Call the SolveQuestion function of the problem(Class) you want.
        // Ex) InnerProduct.SolveQuestion();

        int[,] testCase =
        {
            { 1,1,7,4 }, { 3,2,5,5 },{ 4,3,6,9 }, { 2,6,8,8 }
        };

        DfsBfs dfsBfs = new DfsBfs();
        dfsBfs.solution(testCase, 1, 3, 7, 8);
    }
}
