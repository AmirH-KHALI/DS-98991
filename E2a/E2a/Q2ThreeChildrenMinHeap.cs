using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestCommon;

namespace E2a
{
    public class Q2ThreeChildrenMinHeap : Processor
    {
        public Q2ThreeChildrenMinHeap(string testDataName) : base(testDataName) { }
        public override string Process(string inStr)
        {
            long n;
            long changeIndex, changeValue;
            long[] heap;
            using (StringReader reader = new StringReader(inStr))
            {
                n = long.Parse(reader.ReadLine());

                string line = null;
                line = reader.ReadLine();

                TestTools.ParseTwoNumbers(line, out changeIndex, out changeValue);

                line = reader.ReadLine();
                heap = line.Split(TestTools.IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => long.Parse(x)).ToArray();
            }

            return string.Join("\n", Solve(n, changeIndex, changeValue, heap));

        }
        public long[] Solve(long n, long changeIndex, long changeValue, long[] heap) {
            if (heap[changeIndex] > changeValue) {
                heap[changeIndex] += changeValue;
                siftUp(changeIndex, heap);
            } else {
                heap[changeIndex] += changeValue;
                siftDown(changeIndex, heap);
            }
            return heap;
        }

        private void siftDown(long i, long[] heap) {
            long ch0 = i * 3 + 1;
            long ch1 = i * 3 + 2;
            long ch2 = i * 3 + 3;
            long mn = i;
            if (ch0 < heap.Length && heap[ch0] < heap[mn]) {
                mn = ch0;
            } else if (ch1 < heap.Length && heap[ch1] < heap[mn]) {
                mn = ch1;
            } else if (ch2 < heap.Length && heap[ch2] < heap[mn]) {
                mn = ch2;
            }
            if (mn != i) {
                (heap[mn], heap[i]) = (heap[i], heap[mn]);
                siftDown(mn, heap);
            }
            return;
        }

        private void siftUp(long i, long[] heap) {
            if (i == 0) {
                return;
            }
            long par = (i - 1) / 3;
            if (heap[par] > heap[i]) {
                (heap[par], heap[i]) = (heap[i], heap[par]);
                siftUp(par, heap);
            }
            return;
        }
    }
}
