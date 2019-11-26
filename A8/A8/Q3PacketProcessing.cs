using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q3PacketProcessing : Processor
    {
        public Q3PacketProcessing(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[]>)Solve);

        public long[] Solve(long bufferSize, 
            long[] arrivalTimes, 
            long[] processingTimes)
        {
            Queue<long> endTime = new Queue<long>();

            long now = 0;

            long[] ans = new long[arrivalTimes.Length];

            for (int i = 0; i < arrivalTimes.Length; ++i) {
                while (endTime.Count > 0) {
                    if (arrivalTimes[i] >= endTime.Peek()) {
                        endTime.Dequeue();
                    } else {
                        break;
                    }
                }
                if (endTime.Count < bufferSize) {
                    now = Math.Max(now, arrivalTimes[i]);
                    ans[i] = now;
                    now += processingTimes[i];
                    endTime.Enqueue(now);
                } else {
                    ans[i] = -1;
                }
            }
            return ans;
        }
    }
}