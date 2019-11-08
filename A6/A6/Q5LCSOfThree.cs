using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q5LCSOfThree: Processor
    {
        public Q5LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] str1, long[] str2, long[] str3)
        {
            long[, , ] dp = new long[str1.Length + 1, str2.Length + 1, str3.Length + 1];
            dp[0, 0, 0] = 0;
            for (int i = 0; i <= str1.Length; ++i) {
                for (int j = 0; j <= str2.Length; ++j) {
                    for (int k = 0; k <= str3.Length; ++k) {
                        dp[i, j, k] = 0;
                        if (i > 0) dp[i, j, k] = Math.Max(dp[i, j, k], dp[i - 1, j, k]);
                        if (j > 0) dp[i, j, k] = Math.Max(dp[i, j, k], dp[i, j - 1, k]);
                        if (k > 0) dp[i, j, k] = Math.Max(dp[i, j, k], dp[i, j, k - 1]);
                        if (i > 0 && j > 0 && k > 0 && str1[i - 1] == str2[j - 1] && str2[j - 1] == str3[k - 1]) {
                            dp[i, j, k] = Math.Max(dp[i, j, k], dp[i - 1, j - 1, k - 1] + 1);
                        }
                    }
                }
            }
            return dp[str1.Length, str2.Length, str3.Length];
        }
    }
}
