using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q2PartitioningSouvenirs : Processor
    {
        public Q2PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            bool[] taken = new bool[souvenirsCount];
            long[] subsetSum = new long[3];
            long total = 0;
            for (long i = 0; i < souvenirsCount; ++i) {
                total += souvenirs[i];
            }
            if (total % 3 == 1) {
                return 0;
            }
            if (souvenirsCount == 0)
                return 0;

            if (isPossible(souvenirs, subsetSum, taken, total / 3, souvenirsCount, 0, 0)) {
                return 1;
            } else {
                return 0;
            }
        }

        private bool isPossible(long[] arr, long[] subsetSum, bool[] taken, 
                                long sum, long N, long curPart, long i) {
            if (subsetSum[curPart] == sum) {
                if (curPart == 1)
                    return true;
                else 
                    return isPossible(arr, subsetSum, taken, sum, N, curPart + 1, 0);
            } 
            for (; i < N; ++i) {
                if (taken[i])
                    continue;
                long tmp = subsetSum[curPart] + arr[i]; 
                if (tmp <= sum) {
                    taken[i] = true;
                    subsetSum[curPart] += arr[i];

                    if (isPossible(arr, subsetSum, taken, sum, N, curPart, i + 1))
                        return true;

                    taken[i] = false;
                    subsetSum[curPart] -= arr[i];
                }
            }
            return false;
        }
    }
}
