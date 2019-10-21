using System;
using System.Collections.Generic;
using TestCommon;

namespace E1a
{
    public class Q2UnitFractions : Processor
    {
        public Q2UnitFractions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);


        public virtual long Solve(long nr, long dr)
        {
            nr %= dr;
            long i = 1;
            while (nr > 0) {
                if (dr % nr == 0) {
                    i = dr / nr;
                } else {
                    i = dr / nr;
                    i++;
                }
                if (dr % i == 0 && nr >= dr / i) {
                    nr -= dr / i;
                } else if (dr % i != 0 && nr * i >= dr) {
                    dr *= i;
                    nr *= i;
                    nr -= dr / i;
                }
            }
            return i;
        }
    }
}
