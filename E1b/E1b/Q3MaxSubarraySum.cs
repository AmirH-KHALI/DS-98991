using System;
using TestCommon;

namespace E1b
{
    public class Q3MaxSubarraySum : Processor
    {
        public Q3MaxSubarraySum(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] numbers)
        {
            long[] dp = new long[n];
            dp[0] = numbers[0];
            long ans = dp[0];
            for (int i = 1; i < n; ++i) {
                dp[i] = Math.Max(dp[i - 1] + numbers[i], numbers[i]);
                ans = Math.Max(ans, dp[i]);
            }
            return ans;
        }
    }
}
