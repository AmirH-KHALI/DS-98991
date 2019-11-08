using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q3EditDistance : Processor
    {
        public Q3EditDistance(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {
            long[,] dp = new long[str1.Length + 1, str2.Length + 1];
            dp[0, 0] = 0;
            for (int i = 0; i <= str1.Length; ++i) {
                for (int j = 0; j <= str2.Length; ++j) {
                    if (i == 0 && j == 0) continue;
                    dp[i, j] = long.MaxValue;
                    if (j > 0) dp[i, j] = Math.Min(dp[i, j], dp[i, j - 1] + 1);
                    if (i > 0) dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j] + 1);
                    if (i > 0 && j > 0) {
                        if (str1[i - 1] == str2[j - 1]) {
                            dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j - 1]);
                        } else {
                            dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j - 1] + 1);
                        }
                    }
                }
            }
            return dp[str1.Length, str2.Length];
        }
    }
}
