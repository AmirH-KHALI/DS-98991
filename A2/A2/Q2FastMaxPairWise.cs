using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q2FastMaxPairWise : Processor
    {
        public Q2FastMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) => 
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                 .Select(s => long.Parse(s))
                 .ToArray()).ToString();

        public virtual long Solve(long[] numbers)
        {
            int fi = -1, si = -1;
            for (int i = 0; i < numbers.Length; ++i) {
                if (fi == -1) {
                    fi = i;
                } else if (numbers[i] > numbers[fi]) {
                    fi = i;
                }
            }
            for (int i = 0; i < numbers.Length; ++i) {
                if (i != fi) {
                    if (si == -1) {
                        si = i;
                    } else if (numbers[i] > numbers[si]) {
                        si = i;
                    }
                }
            }
            if (fi != -1 && si != -1) {
                return numbers[fi] * numbers[si];
            }
            return -1;
        }
    }
}
