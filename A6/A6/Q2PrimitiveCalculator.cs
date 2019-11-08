using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q2PrimitiveCalculator : Processor
    {
        public Q2PrimitiveCalculator(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) => 
            TestTools.Process(inStr, (Func<long, long[]>) Solve);

        public long[] Solve(long n)
        {
            long[] dp = new long[n + 1];
            long[] prev = new long[n + 1];
            dp[1] = 1;
            prev[1] = -1;
            for (int i = 2; i <= n; ++i) {
                dp[i] = long.MaxValue;
                if (i - 1 >= 0 && dp[i] >= dp[i - 1] + 1) {
                    dp[i] = dp[i - 1] + 1;
                    prev[i] = i - 1;
                }
                if ((double)i / 2 == (double)((long)i / 2) && i / 2 >= 1 && dp[i] >= dp[i / 2] + 1) {
                    dp[i] = dp[i / 2] + 1;
                    prev[i] = i / 2;
                }
                if ((double)i / 3 == (double)((long)i / 3) && i / 3 >= 1 && dp[i] >= dp[i / 3] + 1) {
                    dp[i] = dp[i / 3] + 1;
                    prev[i] = i / 3;
                }
            }
            ArrayList ans = new ArrayList();
            while (n != -1) {
                ans.Add(n);
                n = prev[n];
            }
            ans.Reverse();
            return (long[])ans.ToArray(typeof(long));
        }
    }
}
