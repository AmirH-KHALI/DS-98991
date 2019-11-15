using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q3MaximizingArithmeticExpression : Processor
    {
        public Q3MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string expression)
        {
            long N = expression.Length / 2 + 1;
            long[,] ansMax = new long[N, N];
            long[,] ansMin = new long[N, N];
            for (long i = 0; i < N; ++i) {
                for (long j = 0; j < N; ++j) {
                    if (j + i >= N) {
                        break;
                    }
                    if (i == 0) {
                        ansMax[i, j] = long.Parse(expression[(int)j * 2].ToString());
                        ansMin[i, j] = long.Parse(expression[(int)j * 2].ToString());
                        continue;
                    }
                    ansMax[i, j] = long.MinValue;
                    ansMin[i, j] = long.MaxValue;
                    for (long k = 0; k < i; ++k) {
                        long aMax = ansMax[k, j];
                        long aMin = ansMin[k, j];
                        long bMax = ansMax[i - k - 1, j + k + 1];
                        long bMin = ansMin[i - k - 1, j + k + 1];
                        switch (expression[(int)(j + k + 1) * 2 - 1]) {
                            case '+':
                            ansMax[i, j] = Math.Max(ansMax[i, j], aMax + bMax);
                            ansMin[i, j] = Math.Min(ansMin[i, j], aMin + bMin);
                            break;
                            case '-':
                            ansMax[i, j] = Math.Max(ansMax[i, j], aMax - bMin);
                            ansMin[i, j] = Math.Min(ansMin[i, j], aMin - bMax);
                            break;
                            case '*':
                            ansMax[i, j] = Math.Max(ansMax[i, j], aMax * bMax);
                            ansMax[i, j] = Math.Max(ansMax[i, j], aMax * bMin);
                            ansMax[i, j] = Math.Max(ansMax[i, j], aMin * bMax);
                            ansMax[i, j] = Math.Max(ansMax[i, j], aMin * bMin);

                            ansMin[i, j] = Math.Min(ansMin[i, j], aMax * bMax);
                            ansMin[i, j] = Math.Min(ansMin[i, j], aMax * bMin);
                            ansMin[i, j] = Math.Min(ansMin[i, j], aMin * bMax);
                            ansMin[i, j] = Math.Min(ansMin[i, j], aMin * bMin);
                            break;
                        }
                    }

                }
            }
            return ansMax[N - 1, 0];
        }
    }
}
