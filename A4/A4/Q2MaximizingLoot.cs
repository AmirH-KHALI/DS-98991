using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q2MaximizingLoot : Processor
    {
        public Q2MaximizingLoot(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long capacity, long[] weights, long[] values)
        {
            ReverseMergeSort(0, weights.Length, weights, values);
            long ans = 0;
            for (long i = 0; i < weights.Length; ++i) {
                if (capacity - weights[i] >= 0) {
                    capacity -= weights[i];
                    ans += values[i];
                } else {
                    ans += (values[i] * capacity / weights[i]);
                    break;
                }
            }

            return ans;
        }

        public void ReverseMergeSort (long l, long r, long[] w, long[] v) {
            if (r - l < 2) {
                return;
            }
            long m = (l + r) / 2;
            ReverseMergeSort(l, m, w, v);
            ReverseMergeSort(m, r, w, v);
            Merge(l, r, w, v);
        }
        public void Merge (long l, long r, long[] w, long[] v) {
            long m = (l + r) / 2;
            long i = l;
            long j = m;
            long k = 0;
            long[] tempW = new long[r - l + 2];
            long[] tempV = new long[r - l + 2];
            
            while (i < m && j < r) {
                if ((double)v[i] / (double)w[i] >= (double)v[j] / (double)w[j]) {
                    tempW[k] = w[i];
                    tempV[k] = v[i];
                    i++;
                    k++;
                } else {
                    tempW[k] = w[j];
                    tempV[k] = v[j];
                    j++;
                    k++;
                }
            }
            while (i < m) {
                tempW[k] = w[i];
                tempV[k] = v[i];
                i++;
                k++;
            }
            while (j < r) {
                tempW[k] = w[j];
                tempV[k] = v[j];
                j++;
                k++;
            }
            for (i = l; i < r; ++i) {
                w[i] = tempW[i - l];
                v[i] = tempV[i - l];
            }
        }

        public override Action<string, string> Verifier { get; set; } =
            TestTools.ApproximateLongVerifier;
    }
}
