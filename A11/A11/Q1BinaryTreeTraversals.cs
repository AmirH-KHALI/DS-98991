using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11 {
    public class Q1BinaryTreeTraversals : Processor {
        public Q1BinaryTreeTraversals(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);

        public long[][] Solve(long[][] nodes) {
            long[][] ans = new long[3][];
            ans[0] = inOrderTraversal(nodes).ToArray();
            ans[1] = preOrderTraversal(nodes).ToArray();
            ans[2] = postOrderTraversal(nodes).ToArray();
            return ans;
        }

        public List<long> postOrderTraversal(long[][] nodes) {
            List<long> ans = new List<long>();
            Stack<long> s = new Stack<long>();
            Stack<long> rAns = new Stack<long>();
            s.Push(0);
            while (s.Count > 0) {
                long tmp = s.Pop();
                rAns.Push(nodes[tmp][0]);
                if (nodes[tmp][1] != -1)
                    s.Push(nodes[tmp][1]);
                if (nodes[tmp][2] != -1)
                    s.Push(nodes[tmp][2]);
            }
            while (rAns.Count > 0)
                ans.Add(rAns.Pop());
            return ans;
        }

        public List<long> preOrderTraversal(long[][] nodes) {
            List<long> ans = new List<long>();
            Stack<long> pathToRoot = new Stack<long>();
            long i = 0;
            while (true) {
                while (i != -1) {
                    ans.Add(nodes[i][0]);
                    pathToRoot.Push(i);
                    i = nodes[i][1];
                }
                if (pathToRoot.Count > 0) {
                    i = pathToRoot.Pop();
                    i = nodes[i][2];
                } else {
                    break;
                }
            }
            return ans;
        }

        public List<long> inOrderTraversal(long[][] nodes) {
            List<long> ans = new List<long>();
            Stack<long> pathToRoot = new Stack<long>();
            long i = 0;
            while (true) {
                while (i != -1) {
                    pathToRoot.Push(i);
                    i = nodes[i][1];
                }
                if (pathToRoot.Count > 0) {
                    i = pathToRoot.Pop();
                    ans.Add(nodes[i][0]);
                    i = nodes[i][2];
                } else {
                    break;
                }
            }
            return ans;
        }
    }
}