using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace E2b
{
    public class Q1ImplementNextForBST : Processor
    {
        public Q1ImplementNextForBST(string testDataName) : base(testDataName) 
        {
            //this.ExcludeTestCaseRangeInclusive(1, 10);
        }
        public override string Process(string inStr)
        {
            long n, node;
            var lines = inStr.Split(TestTools.NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            TestTools.ParseTwoNumbers(lines[0], out n, out node);
            var bst = lines[1].Split(TestTools.IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => long.Parse(x))
                .ToArray();

            return Solve(n, node, bst).ToString();
        }

        public long Solve(long n, long node, long[] bst)
        {
            return next(node, bst);
        }

        public long next(long x, long[] bst) {
            if (getRight(x) < bst.Length && bst[getRight(x)] != -1) {
                return LeftDescendant(getRight(x), bst);
            } else {
                return RightAncestor(x, bst);
            }
        }

        public long RightAncestor(long x, long[] bst) {
            if (bst[x] < bst[parent(x)]) {
                return parent(x);
            }
            if (x == parent(x)) {
                return -1;
            }
            return RightAncestor(parent(x), bst);
        }

        private long parent(long x) {
            return (x - 1) / 2;
        }

        public long LeftDescendant(long x, long[] bst) {
            if (getLeft(x) >= bst.Length || bst[getLeft(x)] == -1) {
                return x;
            }
            return LeftDescendant(getLeft(x), bst);
            
        }

        public long getLeft(long x) {
            return (x * 2) + 1;
        }

        public long getRight(long x) {
            return (x * 2) + 2;
        }
    }
}