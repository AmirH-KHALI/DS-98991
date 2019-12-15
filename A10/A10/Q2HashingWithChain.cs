using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class Q2HashingWithChain : Processor
    {
        public Q2HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);

        protected List<String>[] hashTable;

        public string[] Solve(long bucketCount, string[] commands)
        {
            bSize = bucketCount;
            hashTable = new List<string>[bucketCount];

            for (int i = 0; i < bucketCount; ++i) {
                hashTable[i] = new List<string>();
            }

            List<string> result = new List<string>();
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        Add(arg);
                        break;
                    case "del":
                        Delete(arg);
                        break;
                    case "find":
                        result.Add(Find(arg));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg)));
                        break;
                }
            }
            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;
        public long bSize;

        public static long PolyHash(
            string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX) {
            long hash = 0;

            for (int i = count - 1; i >= start; --i) {
                hash = (hash * x + str[i]) % p;
            }
            
            return hash;
        }

        public void Add(string str)
        {
            long index = PolyHash(str, 0, str.Length) % bSize;
            
            for (int i = 0; i < hashTable[index].Count; ++i) {
                if (hashTable[index][i] == str) {
                    return;
                }
            }

            hashTable[index].Add(str);
            
        }

        public string Find(string str)
        {
            long index = PolyHash(str, 0, str.Length) % bSize;

            for (int i = 0; i < hashTable[index].Count; ++i) {
                if (hashTable[index][i] == str) {
                    return "yes";
                }
            }
            return "no";
        }

        public void Delete(string str)
        {
            long index = PolyHash(str, 0, str.Length) % bSize;

            for (int i = 0; i < hashTable[index].Count; ++i)
            {
                if (hashTable[index][i] == str)
                {
                    hashTable[index].RemoveAt(i);
                    return;
                }
            }
        }

        public string Check(int i)
        {
            if (hashTable[i].Count == 0) {
                return "-";
            }
            return string.Join(" ", hashTable[i].ToArray().Reverse());
        }
    }
}
