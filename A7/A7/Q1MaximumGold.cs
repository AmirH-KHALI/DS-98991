using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q1MaximumGold : Processor
    {
        public Q1MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
            long[, ] ans = new long[W + 1, goldBars.Length];

            for(int i = 1; i <= W; ++i) {
                for (int j = 0; j < goldBars.Length; ++j) {
                    if (j == 0) {
                        ans[i, j] = (i >= goldBars[j]? goldBars[j] : 0);
                    } else if (i >= goldBars[j]) {
                        ans[i, j] = Math.Max(ans[i - goldBars[j], j - 1] + goldBars[j], ans[i, j - 1]);
                    } else {
                        ans[i, j] = ans[i, j - 1];
                    }
                }
            }
            return ans[W, goldBars.Length - 1];
        }
    }
}
