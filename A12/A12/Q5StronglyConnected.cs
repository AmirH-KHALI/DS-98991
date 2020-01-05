﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A12
{
    public class Q5StronglyConnected: Processor
    {
        public Q5StronglyConnected(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            bool[] mark = new bool[nodeCount];
            List<long>[] adj  = new List<long>[nodeCount];
            List<long>[] rAdj = new List<long>[nodeCount];
            List<long> rTopoSort = new List<long>();
            for (int i = 0; i < adj.Length; ++i) {
                adj [i] = new List<long>();
                rAdj[i] = new List<long>();
            }
            for (int i = 0; i < edges.Length; ++i) {
                adj[edges[i][0] - 1].Add(edges[i][1] - 1);
                rAdj[edges[i][1] - 1].Add(edges[i][0] - 1);
            }
            for (int i = 0; i < nodeCount; ++i) {
                if (!mark[i]) {
                    dfs(i, adj, mark, rTopoSort);
                }
            }
            rTopoSort.Reverse();
            List<long> topoSort = rTopoSort;
            mark = new bool[nodeCount];
            long cmp = 0;
            for (int i = 0; i < topoSort.Count; ++i) {
                if (!mark[topoSort[i]]) {
                    cmp++;
                    dfs(topoSort[i], rAdj, mark, new List<long>());
                }
            }
            return cmp;
        }

        private void dfs(long x, List<long>[] adj, bool[] mark, List<long> rTopoSort) {
            mark[x] = true;
            for (int i = 0; i < adj[x].Count; ++i) {
                long child = adj[x][i];
                if (!mark[child]) {
                    dfs(child, adj, mark, rTopoSort);
                }
            }
            rTopoSort.Add(x);
        }
    }
}
