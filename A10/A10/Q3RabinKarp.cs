using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Q3RabinKarp : Processor
    {
        public Q3RabinKarp(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);

        public long[] Solve(string pattern, string text)
        {
            List<long> occurrences = new List<long>();

            long[] hashArray = PreComputeHashes(text, pattern.Length, 1000000000 + 7, 263);
            long pHash = PreComputeHashes(pattern, pattern.Length, 1000000000 + 7, 263)[0];

            for (int i = 0; i < hashArray.Length; ++i) {
                if (hashArray[i] == pHash && pattern == text.Substring(i, pattern.Length))
                    occurrences.Add(i);
            }

            return occurrences.ToArray();
        }


        public static long[] PreComputeHashes(
            string T, 
            int P, 
            long p, 
            long x)
        {
            long powX = 1;

            long[] hash = new long[T.Length - P + 1];
            for (int i = T.Length - 1; i >= T.Length - P; --i) {
                hash[T.Length - P] = (hash[T.Length - P] * x + T[i]) % p;
                powX *= x;
                powX %= p;
            }


            for (long i = T.Length - P - 1; i >= 0; --i) {
                hash[i] = (hash[i + 1] * x + (T[(int)i] - T[(int)i + P] * powX) % p) % p;
                hash[i] += p;
                hash[i] %= p;
            }

            return hash;
        }
    }
}
