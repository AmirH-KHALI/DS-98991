using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A3
{
    public class Q1MergeSort : Processor
    {
        public Q1MergeSort(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Solve(long n, long[] a)
        {
            sort(a, 0, n);
            return a;
        }

        public void sort (long[] a, long l, long r) {
            
            if (l + 1 >= r) {
                return;
            }

            long m = (l + r) / 2;

            sort(a, l, m);
            sort(a, m, r);
            merge(a, l, r);
	    }   

        public void merge (long[] a, long l, long r) {

            long m = (l + r) / 2;

            long i = l;
            long j = m;
            long k = 0;

            long[] ncb = new long[r - l];

            while (i < m && j < r) {
                if (a[i] > a[j]) {
                    ncb[k] = a[j];
                    j++;
                } else {
                    ncb[k] = a[i];
                    i++;
                }
                k++;
            }
            while (i < m) {
                ncb[k] = a[i];
                i++;
                k++;
            }
            while (j < r) {
                ncb[k] = a[j];
                j++;
                k++;
            }
            for (k = 0; k < r - l; ++k) {
                a[k + l] = ncb[k];
            }
        }

        public static void Main(string[] args) {

        }
    }
}
