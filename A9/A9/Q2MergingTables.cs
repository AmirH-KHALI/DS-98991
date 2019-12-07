using System;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q2MergingTables : Processor
    {
        long[] parent;
        long[] tableSizes;
        long[] rank;

        public Q2MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);


        public long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        {
            long[] par = new long[tableSizes.Length];

            long[] ans = new long[targetTables.Length];

            for (int i = 0; i < tableSizes.Length; ++i) {
                par[i] = i;
            }

            long mx = Int64.MinValue;

            for (int i = 0; i < tableSizes.Length; ++i) {
                mx = Math.Max(mx, tableSizes[i]);
            }

            for (int i = 0; i < targetTables.Length; ++i) {
                targetTables[i] = find(targetTables[i], par);
                sourceTables[i] = find(sourceTables[i], par);
                if (targetTables[i] != sourceTables[i]) {
                    tableSizes[targetTables[i] - 1] += tableSizes[sourceTables[i] - 1];
                    par[sourceTables[i]] = targetTables[i];
                }
                ans[i] = Math.Max(tableSizes[targetTables[i] - 1], mx);
                mx = ans[i];
            }
            return ans;
        }

        private long find(long v, long[] par) {
            if (par[v] == v) 
                return v;
            return par[v] = find(par[v], par);
        }

    }
}
