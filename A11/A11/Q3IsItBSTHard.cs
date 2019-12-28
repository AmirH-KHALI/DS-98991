using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q3IsItBSTHard : Processor
    {
        public Q3IsItBSTHard(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);

        public bool Solve(long[][] nodes)
        {
            return isBST(nodes);
        }

        private bool isBST(long[][] nodes) {
            bool ans = true;
            Stack<long> pathToRoot = new Stack<long>();
            long[] mx = new long[nodes.Length];
            long[] mn = new long[nodes.Length];
            bool[] mark = new bool[nodes.Length];
            for (int j = 0; j < nodes.Length; ++j) {
                mx[j] = long.MinValue;
                mn[j] = long.MaxValue;
            }
            long i = 0;
            while (true) {
                mark[i] = true;
                if (nodes[i][1] != -1 && !mark[nodes[i][1]]) {
                    pathToRoot.Push(i);
                    i = nodes[i][1];
                } else if (nodes[i][2] != -1 && !mark[nodes[i][2]]) {
                    pathToRoot.Push(i);
                    i = nodes[i][2];
                } else if (pathToRoot.Count > 0) {
                    if ((nodes[i][1] != -1 && mx[nodes[i][1]] >= nodes[i][0]) ||
                         (nodes[i][2] != -1 && mn[nodes[i][2]] < nodes[i][0])) {
                        ans = false;
                        break;
                    }
                    mx[i] = mn[i] = nodes[i][0];
                    if (nodes[i][2] != -1) {
                        mx[i] = Math.Max(mx[nodes[i][2]], mx[i]);
                    }
                    if (nodes[i][1] != -1) {
                        mn[i] = Math.Min(mn[nodes[i][1]], mn[i]);
                    }
                    i = pathToRoot.Pop();
                } else {
                    break;
                }
            }
            return ans;
        }
    }
}
