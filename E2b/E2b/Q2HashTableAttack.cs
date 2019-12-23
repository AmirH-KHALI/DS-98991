using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestCommon;

namespace E2b
{
    public class Q2HashTableAttack : Processor
    {
        public Q2HashTableAttack (string testDataName) : base(testDataName) 
        {
        }

        public override string Process(string inStr)
        {
            long bucketCount = long.Parse(inStr);
            return string.Join("\n", Solve(bucketCount));
        }

        public string[] Solve(long bucketCount) {
            int ansSize = (int)((bucketCount * 9) / 10);
            List<string>[] ncb = new List<string>[bucketCount];
            List<string> ans = new List<string>();

            for (int i = 0; i < bucketCount; ++i) {
                ncb[i] = new List<string>();
            }

            for (long i = 1; i <= bucketCount * bucketCount; ++i) {
                string str = getStr(i);
                long hash = GetBucketNumber(str, bucketCount);
                ncb[hash].Add(str);
                if (ncb[hash].Count == ansSize) {
                    ans = ncb[hash];
                    break;
                }
            }
            return ans.ToArray();
        }

        private string getStr(long i) {
            string ans = "";
            while(i > 0) {
                ans += (char)('a' + (i % 26) - 1);
                i /= 26;
            }
            return ans;
        }

        #region Chars
        static char[] LowChars = Enumerable
            .Range(0, 26)
            .Select(n => (char)('a' + n))
            .ToArray();

        static char[] CapChars = Enumerable
            .Range(0, 26)
            .Select(n => (char)('A' + n))
            .ToArray();

        static char[] Numbers = Enumerable
            .Range(0, 10)
            .Select(n => (char)('0' + n))
            .ToArray();

        static char[] AllChars = 
            LowChars.Concat(CapChars).Concat(Numbers).ToArray();
        #endregion


        // پیاده‌سازی مورد استفاده دات‌نت برای پیدا کردن شماره باکت
        // https://referencesource.microsoft.com/#mscorlib/system/collections/generic/dictionary.cs,bcd13bb775d408f1
        public static long GetBucketNumber(string str, long bucketCount) =>
            (str.GetHashCode() & 0x7FFFFFFF) % bucketCount;
    }
}
