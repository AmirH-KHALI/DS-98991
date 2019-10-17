using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Globalization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q6MaximizeSalary : Processor
    {
        public Q6MaximizeSalary(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>) Solve);


        public virtual string Solve(long n, long[] numbers)
        {
            MergeSort(0, n, numbers);
            string ans = "";
            for (int i = 0; i < n; ++i) {
                ans += numbers[i].ToString();
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
                if (compare(a[i], a[j])) {
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

        public bool compare (long x, long y) {
            String s1 = x.ToString() + y.ToString();
            String s2 = y.ToString() + x.ToString();
            if (Convert.ToInt64(s1) < Convert.ToInt64(s2)) {
                return false;
            }
            return true;
        }
    }
}

