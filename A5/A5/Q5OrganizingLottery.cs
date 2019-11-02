using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q5OrganizingLottery:Processor
    {
        public Q5OrganizingLottery(string testDataName) : base(testDataName)
        {}
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public virtual long[] Solve(long[] points, long[] startSegments, long[] endSegment)
        {
            long pl = points.Length;
            long sl = startSegments.Length;
            long el = endSegment.Length;
            long[] help = new long[pl];
            for (long i = 0; i < pl; ++i) {
                help[i] = i;
            }
            ms(points, help, 0, pl);
            Array.Sort(startSegments);
            Array.Sort(endSegment);
            long[] ans = new long[pl];
            long num = 0;
            for (long i = 0, j = 0, k = 0; i < pl; ++i) {
                while (j < sl && k < el && (startSegments[j] <= points[i] || endSegment[k] < points[i])) {
                    if (startSegments[j] <= endSegment[k]) {
                        j++;
                        num++;
                    } else {
                        k++;
                        num--;
                    }
                }
                while (j < sl && startSegments[j] <= points[i]) {
                    j++;
                    num++;
                }
                while (k < el && endSegment[k] < points[i]) {
                    k++;
                    num--;
                }
                ans[i] = num;
            }
            ms(help, ans, 0, pl);
            return ans;
        }
        private void ms(long[] a, long[] b, long l, long r) {
            if (r - l <= 1) {
                return;
            }
            long m = (l + r) / 2;
            ms(a, b, l, m);
            ms(a, b, m, r);
            merge(a, b, l, m, r);
        }

        private void merge(long[] a, long[] b, long l, long m, long r) {
            long[] temp  = new long[r - l];
            long[] tempB = new long[r - l];
            long i = l;
            long j = m;
            long k = 0;
            while (i < m && j < r) {
                if (a[j] < a[i]) {
                    temp [k] = a[j];
                    tempB[k] = b[j];
                    j++;
                    k++;
                } else {
                    temp [k] = a[i];
                    tempB[k] = b[i];
                    i++;
                    k++;
                }
            }
            while (j < r) {
                temp [k] = a[j];
                tempB[k] = b[j];
                j++;
                k++;
            }
            while (i < m) {
                temp [k] = a[i];
                tempB[k] = b[i];
                i++;
                k++;
            }
            for (k = 0; k < r - l; ++k) {
                a[l + k] = temp [k];
                b[l + k] = tempB[k];
            }
        }
    }
}
