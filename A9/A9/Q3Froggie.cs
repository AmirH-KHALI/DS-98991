//using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q3Froggie : Processor
    {
        public Q3Froggie(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[], long[], long>)Solve);

        public long Solve(long initialDistance, long initialEnergy, long[] distance, long[] food)
        {
            List<long> ind = new List<long>();

            List<long> heap = new List<long>();

            long ans = 0;

            long pos = initialDistance;
            
            for (int i = 0; i < distance.Length; ++i) {
                ind.Add(i);
            }

            ind.Sort(delegate (long x, long y)
            {
                return distance[y].CompareTo(distance[x]);
            });

            for (int i = 0; i < ind.Count; ++i) {
                initialEnergy -= pos - distance[ind[i]];
                pos = distance[ind[i]];
                while(initialEnergy < 0) {
                    long en = extMax(heap);
                    if (en == -1)
                        return -1;
                    initialEnergy += en;
                    ans++;
                }
                insert(heap, food[ind[i]]);
            }
            initialEnergy -= pos;
            while (initialEnergy < 0) {
                long en = extMax(heap);
                if (en == -1)
                    return -1;
                initialEnergy += en;
                ans++;
            }
            return ans;
        }

        private void insert(List<long> heap, long v) {
            heap.Add(v);
            siftUp((int)heap.Count - 1, heap);
        }

        private void siftUp(int i, List<long> heap) {
            while (i != 0) {
                int par = (i - 1) / 2;
                if (comp(heap[i], heap[par])) {
                    (heap[i], heap[par]) = (heap[par], heap[i]);
                    i = par;
                } else break;
            } 
        }

        private void siftDown(int i, List<long> heap) {
            while (true) {
                int min = i;
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                if (left < heap.Count && comp(heap[left], heap[min])) {
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

        private bool comp(long v1, long v2) {
            return v1 > v2;
        }

        private long extMax(List<long> heap) {
            if (heap.Count == 0)
                return -1;
            long ans = heap[0];
            (heap[0], heap[heap.Count - 1]) = (heap[heap.Count - 1], heap[0]);
            heap.RemoveAt(heap.Count - 1);
            siftDown(0, heap);
            return ans;
        }
    }
}
