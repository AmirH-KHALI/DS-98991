using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace E2a
{
    public class Q1BSTInOrderTraverse : Processor
    {
        public Q1BSTInOrderTraverse(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Solve(long n, long[] bst)
        {
            long[] ans = print(0, bst).ToArray();
            return ans;
        }

        private List<long> print(long id, long[] bst) {
            if (id >= bst.Length || bst[id] == -1) {
                return new List<long>();
            }
            List<long> ans = new List<long>();
            ans.AddRange(print(2 * id + 1, bst));
            ans.Add(bst[id]);
            ans.AddRange(print(2 * id + 2, bst));
            return ans;
        }
    }
}