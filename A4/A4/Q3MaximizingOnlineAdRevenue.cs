using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q3MaximizingOnlineAdRevenue : Processor
    {
        public Q3MaximizingOnlineAdRevenue(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long slotCount, long[] adRevenue, long[] averageDailyClick)
        {
            MergeSort(0, slotCount, adRevenue);
            MergeSort(0, slotCount, averageDailyClick);
            long ans = 0;
            for (long i = 0; i < slotCount; ++i) {
                ans += adRevenue[i] * averageDailyClick[i];
            }
            return ans;

        }
        public void MergeSort (long l, long r, long[] a) {
            if (r - l < 2) {
                return;
            }
            long m = (l + r) / 2;
            MergeSort(l, m, a);
            MergeSort(m, r, a);
            Merge(l, r, a);
        }
        public void Merge (long l, long r, long[] a) {
            long m = (l + r) / 2;
            long i = l;
            long j = m;
            long k = 0;
            long[] temp = new long[r - l + 2];
            
            while (i < m && j < r) {
                if (a[i] < a[j]) {
                    temp[k] = a[i];
                    i++;
                    k++;
                } else {
                    temp[k] = a[j];
                    j++;
                    k++;
                }
            }
            while (i < m) {
                temp[k] = a[i];
                i++;
                k++;
            }
            while (j < r) {
                temp[k] = a[j];
                j++;
                k++;
            }
            for (i = l; i < r; ++i) {
                a[i] = temp[i - l];
            }
        }
    }
}
