using System;
using TestCommon;

namespace A3
{
    public class Q8FibonacciPartialSum : Processor
    {
        public Q8FibonacciPartialSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            if (a > b) {
                long c = b;
                b = a;
                a = c;
            }
            long first = 0, second = 1;
            long[] dp = new long[1000000 + 20];
            long[] ps = new long[1000000 + 20];
            ps[0] = dp[0] = first;
            ps[1] = dp[1] = second;
            int i = 2; 
            do {
                dp[i] = (dp[i - 1] + dp[i - 2]) % 10;
                ps[i] = (ps[i - 1] + dp[i]) % 10;
                ++i;
            } while(!(first == dp[i - 2] && second == dp[i - 1]));
            long m = i - 2;
            return ((ps[b % m] + (b / m) * ps[m - 1])
                - (ps[(a - 1) % m] + ((a - 1) / m) * ps[m - 1]) + 10 ) % 10;
        }
    }
}
