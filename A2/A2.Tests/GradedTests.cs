using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;
using System.Threading;

namespace A2.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod()]
        public void SolveTest_Q1NaiveMaxPairWise()
        {
            RunTest(new Q1NaiveMaxPairWise("TD1"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q2FastMaxPairWise()
        {
            RunTest(new Q2FastMaxPairWise("TD2"));
        }

        [TestMethod()]
        public void SolveTest_StressTest()
        {
            Q1NaiveMaxPairWise solver1 = new Q1NaiveMaxPairWise("TD1");
            Q2FastMaxPairWise solver2 = new Q2FastMaxPairWise("TD2");

            Random random = new Random();

            Stopwatch s = new Stopwatch();
            s.Start();

            while (s.ElapsedMilliseconds < 5000) {

                int TestSize = random.Next(2, 2 * 10000);
                long [] TestArray = new long [TestSize];
                for (int i = 0; i < TestSize; ++i) {
                    TestArray[i] = random.Next(1, 2 * 10000);
                }

                long naiveResult = solver1.Solve(TestArray);
                long fastResult = solver2.Solve(TestArray);
                
                Assert.AreEqual(naiveResult, fastResult);
            }
            
            s.Stop();
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A2", p.Process, p.TestDataName, p.Verifier);
        }
    }
}