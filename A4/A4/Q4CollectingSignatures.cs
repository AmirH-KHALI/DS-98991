using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q4CollectingSignatures : Processor
    {
        public Q4CollectingSignatures(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long tenantCount, long[] startTimes, long[] endTimes)
        {
            MergeSort(0, tenantCount, startTimes, endTimes);
            long ans = 0;
            long lastPoint = -1;
            for (long i = 0; i < tenantCount; ++i) {
                if (startTimes[i] > lastPoint) {
                    lastPoint = endTimes[i];
                    ans++;
                }
            }
            return ans;
        }

        public void MergeSort (long l, long r, long[] w, long[] v) {
            if (r - l < 2) {
                return;
            }
            long m = (l + r) / 2;
            MergeSort(l, m, w, v);
            MergeSort(m, r, w, v);
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
                if (v[i] < v[j]) {
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
    }
}
