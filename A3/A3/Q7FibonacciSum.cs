using System;
using TestCommon;

namespace A3
{
    public class Q7FibonacciSum : Processor
    {
        public Q7FibonacciSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
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
            return (ps[n % m] + (n / m) * ps[m - 1]) % 10;
        }
    }
}
