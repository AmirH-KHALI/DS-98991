using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q1ConvertIntoHeap : Processor
    {
        public Q1ConvertIntoHeap(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long[] array)
        {
            List<Tuple<long, long>> ans = new List<Tuple<long, long>>();
            
            for (int i = array.Length / 2; i >= 0; --i) {
                siftDown(i, array, ans);
            }
            return ans.ToArray();
        }

        private void siftDown(int i, long[] array, List<Tuple<long, long>> ans) {
            while (true) {
                if (i * 2 + 1 >= array.Length) break;
                else if (i * 2 + 2 >= array.Length) {
                    if (array[i] > array[2 *  i + 1]) {
                        (array[i], array[2 * i + 1]) = (array[2 * i + 1], array[i]);
                        ans.Add(new Tuple<long, long>(i, 2 * i + 1));
                        i = 2 * i + 1;
                    } else {
                        break;
                    }
                }
                else if (array[2 * i + 2] > array[2 * i + 1] && array[i] > array[2 * i + 1]) {
                    (array[i], array[2 * i + 1]) = (array[2 * i + 1], array[i]);
                    ans.Add(new Tuple<long, long>(i, 2 * i + 1));
                    i = 2 * i + 1;
                } else if (array[i] > array[2 * i + 2]) {
                    (array[i], array[2 * i + 2]) = (array[2 * i + 2], array[i]);
                    ans.Add(new Tuple<long, long>(i, 2 * i + 2));
                    i = 2 * i + 2;
                } else break;
            }
        }
    }
}
