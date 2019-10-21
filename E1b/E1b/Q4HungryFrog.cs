using System;
using TestCommon;

namespace E1b
{
    public class Q4HungryFrog : Processor
    {
        public Q4HungryFrog(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public virtual long Solve(long n, long p, long[][] numbers)
        {
            long[, ] dp = new long[2, n];
            dp[0, 0] = numbers[0][0];
            dp[1, 0] = numbers[1][0];
            // n = 6;
            for (int i = 1; i < n; ++i) {
                dp[0, i] = numbers[0][i] + Math.Max(dp[0, i - 1],
                                                    dp[1, i - 1] - p);
                dp[1, i] = numbers[1][i] + Math.Max(dp[1, i - 1],
                                                    dp[0, i - 1] - p);
            }
            return Math.Max(dp[0, n - 1], dp[1, n - 1]);
        }
    }
}
