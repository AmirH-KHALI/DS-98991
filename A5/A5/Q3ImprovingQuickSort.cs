using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q3ImprovingQuickSort:Processor
    {
        public Q3ImprovingQuickSort(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public virtual long[] Solve(long n, long[] a)
        {
            qsort(a, 0, n - 1);
            return a;
        }

        private void qsort(long[] a, long l, long r) {

            if (r <= l) return;

            long m1 = -1;
            long m2 = -1;
            partition(a, l, r, ref m1, ref m2);

            qsort(a, l, m1 - 1);
            qsort(a, m2 + 1, r);
        }

        private void partition(long[] a, long l, long r, ref long m1, ref long m2) {
            long i = l;
            long j = l + 1;
            long p = a[l];
            while (j <= r) {
                if (a[j] < p) {
                    i++;
                    (a[i], a[j]) = (a[j], a[i]);
                }
                j++;
            }
            (a[i], a[l]) = (a[l], a[i]);
            m1 = i;
            for (long k = i + 1; k <= r; ++k) {
                if (a[k] == p) {
                    i++;
                    (a[k], a[i]) = (a[i], a[k]);
                }
            }
            m2 = i;
            return;
        }
    }
}
