using System;
using TestCommon;

namespace A3
{
    public class Q6FibonacciMod : Processor
    {
        public Q6FibonacciMod(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long n, long m)
        {
            long first = 0, second = 1;
            long[] dp = new long[1000000 + 20];
            dp[0] = first;
            dp[1] = second;
            int i = 2; 
            do {
                dp[i] = (dp[i - 1] + dp[i - 2]) % m;
                ++i;
            } while(!(first == dp[i - 2] && second == dp[i - 1]));
            return dp[n % (i - 2)];
        }
    }
}
