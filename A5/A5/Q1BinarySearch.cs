using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q1BinarySearch : Processor
    {
        public Q1BinarySearch(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long [], long[]>)Solve);


        public virtual long[] Solve(long []a, long[] b) {
            for (int i = 0; i < b.Length; ++i) {
                b[i] = bs(b[i], a, 0, a.Length);
            }
            return b;
        }

        private long bs(long x, long[] a, long l, long r) {
            if (r - l < 2) { 
                if (a[l] == x) {
                    return l;
                } else {
                    return -1; 
                }
            }
            long m = (l + r) / 2;
            if (x < a[m]) return bs(x, a, l, m);
            else return bs(x, a, m, r);
        }
    }
}
