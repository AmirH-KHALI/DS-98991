using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;


namespace A5
{
    public class Q4NumberOfInversions:Processor
    {

        public Q4NumberOfInversions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public virtual long Solve(long n, long[] a) {
            return ms(a, 0, n);
        }

        private long ms(long[] a, long l, long r) {
            if (r - l <= 1) {
                return 0;
            }
            long m = (l + r) / 2;
            return
                ms(a, l, m) +
                ms(a, m, r) +
                merge(a, l, m, r);
        }

        private long merge(long[] a, long l, long m, long r) {
            long[] temp = new long[r - l];
            long ans = 0;
            long i = l;
            long j = m;
            long k = 0;
            while (i < m && j < r) {
                if (a[j] < a[i]) {
                    temp[k] = a[j];
                    j++;
                    k++;
                    ans += m - i;
                } else {
                    temp[k] = a[i];
                    i++;
                    k++;
                }
            }
            while (j < r) {
                temp[k] = a[j];
                j++;
                k++;
            }
            while (i < m) {
                temp[k] = a[i];
                i++;
                k++;
            }
            for (k = 0; k < r - l; ++k) {
                a[l + k] = temp[k];
            }
            return ans;

        }
    }
}
