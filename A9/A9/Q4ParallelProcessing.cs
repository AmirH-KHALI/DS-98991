using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q4ParallelProcessing : Processor
    {
        public Q4ParallelProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            List<Tuple<long, long>> heap = new List<Tuple<long, long>>();

            List<Tuple<long, long>> ans = new List<Tuple<long, long>>();

            //*
            for (int i = 0; i < threadCount; ++i) {
                if (i == 0) heap.Add(new Tuple<long, long>(i, 0));
                else heap.Add(new Tuple<long, long>(threadCount - i, 0));
            }

            for (int i = 0; i < jobDuration.Length; ++i) {
                Tuple<long, long> mn = extMin(heap);
                ans.Add(mn);
                Tuple<long, long> newThread = new Tuple<long, long>(mn.Item1, mn.Item2 + jobDuration[i]);
            }
            /*/
            for (int i = 0; i < threadCount; ++i) {
                ans.Add(new Tuple<long, long>(i, 0));
            }
            //*/

            return ans.ToArray();
        }

        private Tuple<long, long> extMin(List<Tuple<long, long>> heap) {
            Tuple<long, long> ans = heap[0];
            (heap[0], heap[heap.Count - 1]) = (heap[heap.Count - 1], heap[0]);
            heap.RemoveAt(heap.Count - 1);
            siftDown(0, heap);
            return ans;
        }

        private void siftDown(int i, List<Tuple<long, long>> heap) {
            while (true) {
                int min = i;
                int left  = 2 * i + 1;
                int right = 2 * i + 2;
                if (left  < heap.Count && comp(heap[left] , heap[min])) {
                    min = left;
                }
                if (right < heap.Count && comp(heap[right], heap[min])) {
                    min = right;
                }
                if (min == i) {
                    break;
                }
                (heap[i], heap[min]) = (heap[min], heap[i]);
                i = min;
            }
        }

        private bool comp(Tuple<long, long> tuple1, Tuple<long, long> tuple2) {
            return tuple1.Item2 < tuple2.Item2;
        }
    }
}
