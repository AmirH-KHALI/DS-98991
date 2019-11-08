using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q1MoneyChange: Processor
    {
        private static readonly int[] COINS = new int[] {1, 3, 4};

        public Q1MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        public long Solve(long n)
        {
            long[] dp = new long[n + 1];
            for (int i = 1; i <= n; ++i) {
                dp[i] = long.MaxValue;
                if (i >= 1) dp[i] = Math.Min(dp[i], dp[i - 1] + 1);
                if (i >= 3) dp[i] = Math.Min(dp[i], dp[i - 3] + 1);
                if (i >= 4) dp[i] = Math.Min(dp[i], dp[i - 4] + 1);
            }
            return dp[n];
        }
    }
}
