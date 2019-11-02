using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q2MajorityElement:Processor
    {

        public Q2MajorityElement(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] a)
        {
            long last = -1;
            long num = 0;
            for (int i = 0; i < n; ++i) {
                if (num == 0) {
                    last = a[i];
                }

                if (last == a[i]) {
                    num++;
                } else {
                    num--;
                }
            }
            num = 0;
            for (int i = 0; i < n; ++i) {
                if (a[i] == last) {
                    num++;
                }
            }
            if (num > n / 2) return 1;
            else return 0;
        }
    }
}
