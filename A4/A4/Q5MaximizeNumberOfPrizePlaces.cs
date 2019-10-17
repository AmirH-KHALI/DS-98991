using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q5MaximizeNumberOfPrizePlaces : Processor
    {
        public Q5MaximizeNumberOfPrizePlaces(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>) Solve);


        public virtual long[] Solve(long n)
        {
            ArrayList ncb = new ArrayList();
            long i = 1;
            while (true) {
                if (n - i >= 0) {
                    ncb.Add(i);
                    // ans[i - 1] = i;
                    n -= i;
                    i++;
                } else {
                    // ans[i - 2] += n;
                    break;
                }
            }
            long[] ans = new long[ncb.Count];
            i = 0;
            foreach (long j in ncb) {
                ans[i] = j;
                i++;
            }
            ans[ncb.Count - 1] += n;
            return ans;
        }
    }
}

