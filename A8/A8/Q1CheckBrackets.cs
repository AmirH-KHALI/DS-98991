using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q1CheckBrackets : Processor
    {
        public Q1CheckBrackets(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string str)
        {
            List<long> ncb = new List<long>();
            for (int i = 0; i < str.Length; ++i) {

                if (str[i] == '(' || str[i] == '{' || str[i] == '[') {
                    ncb.Add(i);
                } else if (str[i] == ')' || str[i] == '}' || str[i] == ']') {
                    if (ncb.Count == 0) {
                        return i + 1;
                    } else if (str[(int)ncb[ncb.Count - 1]] == '(' && str[i] == ')') {
                        ncb.RemoveAt(ncb.Count - 1);
                    } else if (str[(int)ncb[ncb.Count - 1]] == '{' && str[i] == '}') {
                        ncb.RemoveAt(ncb.Count - 1);
                    } else if (str[(int)ncb[ncb.Count - 1]] == '[' && str[i] == ']') {
                        ncb.RemoveAt(ncb.Count - 1);
                    } else {
                        return i + 1;
                    }
                }
            }
            if(ncb.Count > 0) {
                return ncb[0] + 1;
            }
            return -1;
        }
    }
}
