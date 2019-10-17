using System.Net.Http.Headers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlTypes;
using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q1ChangingMoney : Processor
    {
        public Q1ChangingMoney(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);


        public virtual long Solve(long n)
        {
            long n10 = n / 10;
            n %= 10;
            long n5 = n / 5;
            n %= 5;
            return n10 + n5 + n;
        }

        public static void Main (String[] Args) {

        } 
    }
}
