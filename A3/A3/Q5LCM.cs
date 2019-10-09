using System;
using TestCommon;

namespace A3
{
    public class Q5LCM : Processor
    {
        public Q5LCM(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            return (a * b) / gcd(a, b);
        }

        public long gcd (long a, long b) {
            
            if (b > a) {
                long c = b;
                b = a;
                a = c;
            }

            if (b == 0) return a;
            return gcd(b, a % b);            
        }
    }
}
