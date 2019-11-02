using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q6ClosestPoints : Processor
    {
        public Q6ClosestPoints(string testDataName) : base(testDataName)
        { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], double>)Solve);

        public virtual double Solve(long n, long[] xPoints, long[] yPoints)
        {
            ms(xPoints, yPoints, 0, n);
            return closestPoints(xPoints, yPoints, 0, n); 
        }

        private double closestPoints(long[] xPoints, long[] yPoints, long l, long r) {
            if (r - l <= 1) {
                return 1e9 + 7;
            }
            long m = (l + r) / 2;
            double dl = closestPoints(xPoints, yPoints, l, m);
            double dr = closestPoints(xPoints, yPoints, m, r);
            double d = Math.Min(dl, dr);
            double ans = d;
            for (long i = m; i < r && xPoints[i] - xPoints[m] < d; ++i) {
                for (long j = m - 1; j >= l && xPoints[m] - xPoints[j] < d; --j) {
                    double x = xPoints[i] - xPoints[j];
                    double y = yPoints[i] - yPoints[j];
                    double dist = Math.Sqrt(x * x + y * y);
                    ans = Math.Min(ans, dist);
                }
            }
            return Math.Round(ans, 4);
        }
        private void ms(long[] a, long[] b, long l, long r) {
            if (r - l <= 1) {
                return;
            }
            long m = (l + r) / 2;
            ms(a, b, l, m);
            ms(a, b, m, r);
            merge(a, b, l, m, r);
        }

        private void merge(long[] a, long[] b, long l, long m, long r) {
            long[] temp = new long[r - l];
            long[] tempB = new long[r - l];
            long i = l;
            long j = m;
            long k = 0;
            while (i < m && j < r) {
                if (a[j] < a[i]) {
                    temp[k] = a[j];
                    tempB[k] = b[j];
                    j++;
                    k++;
                } else {
                    temp[k] = a[i];
                    tempB[k] = b[i];
                    i++;
                    k++;
                }
            }
            while (j < r) {
                temp[k] = a[j];
                tempB[k] = b[j];
                j++;
                k++;
            }
            while (i < m) {
                temp[k] = a[i];
                tempB[k] = b[i];
                i++;
                k++;
            }
            for (k = 0; k < r - l; ++k) {
                a[l + k] = temp[k];
                b[l + k] = tempB[k];
            }
        }
    }
}