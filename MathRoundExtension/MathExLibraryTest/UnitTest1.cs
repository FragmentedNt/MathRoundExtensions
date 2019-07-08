using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MathRoundExtension;
using static MathRoundExtension.MathEx;

namespace MathExLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRound()
        {
            var vals = new[] { 0, 3.14159265, -3.14159265, 1000.01, -1000.01, 999.99999999, -999.99999999, 0.0010001, -0.0010001, 0.0000099999, -0.0000099999 };
            var ans = new[] { 0, 3.142, -3.142, 1000, -1000, 1000, -1000, 0.001000, -0.001000, 0.0000100000, -0.0000100000 };
            for (int i = 0; i < vals.Length; i++)
            {
                var result = MathEx.Round(vals[i], 4);
                Assert.AreEqual(result, ans[i], $"Expected for '{ans[i]}': false, Actual:{result}");
            }
        }

        [TestMethod]
        public void TestRoundUp()
        {
            var vals = new[] { 0, 3.14159265, -3.14159265, 1000.01, -1000.01, 999.99999999, -999.99999999, 0.0010001, -0.0010001, 0.0000099999, -0.0000099999 };
            var ans = new[] { 0, 3.142, -3.141, 1001, -1000, 1000, -999.9, 0.0010010, -0.0010000, 0.0000100000, -0.0000099990 };
            for (int i = 0; i < vals.Length; i++)
            {
                var result = MathEx.RoundUp(vals[i], 4);
                Assert.AreEqual(result, ans[i], $"Expected for '{ans[i]}': false, Actual:{result}");
            }
        }

        [TestMethod]
        public void TestRoundDown()
        {
            var vals = new[] { 0, 3.14159265, -3.14159265, 1000.01, -1000.01, 999.99999999, -999.99999999, 0.0010001, -0.0010001, 0.0000099999, -0.0000099999 };
            var ans = new[] { 0, 3.141, -3.142, 1000, -1001, 999.9, -1000, 0.0010000, -0.0010010, 0.0000099990, -0.0000100000 };
            for (int i = 0; i < vals.Length; i++)
            {
                var result = MathEx.RoundDown(vals[i], 4);
                Assert.AreEqual(result, ans[i], $"Expected for '{ans[i]}': false, Actual:{result}");
            }
        }

        [TestMethod]
        public void TestTrimUp()
        {
            var vals = new[] { 0, 3.14159265, -3.14159265, 1000.01, -1000.01, 999.99999999, -999.99999999, 0.0010001, -0.0010001, 0.0000099999, -0.0000099999 };
            var ans = new[] { 0, 3.142, -3.142, 1001, -1001, 1000, -1000, 0.0010010, -0.0010010, 0.0000100000, -0.0000100000 };
            for (int i = 0; i < vals.Length; i++)
            {
                var result = MathEx.TrimUp(vals[i], 4);
                Assert.AreEqual(result, ans[i], $"Expected for '{ans[i]}': false, Actual:{result}");
            }
        }

        [TestMethod]
        public void TestTrimDown()
        {
            var vals = new[] { 0, 3.14159265, -3.14159265, 1000.01, -1000.01, 999.99999999, -999.99999999, 0.0010001, -0.0010001, 0.0000099999, -0.0000099999 };
            var ans = new[] { 0, 3.141, -3.141, 1000.00, -1000.00, 999.9, -999.9, 0.0010000, -0.0010000, 0.0000099990, -0.0000099990 };
            for (int i = 0; i < vals.Length; i++)
            {
                var result = MathEx.TrimDown(vals[i], 4);
                Assert.AreEqual(result, ans[i], $"Expected for '{ans[i]}': false, Actual:{result}");
            }
        }

        [TestMethod]
        public void TestNormalize()
        {
            var vals = new[] { 0, 3.14159265, -3.14159265, 1000.01, -1000.01, 999.99999999, -999.99999999, 0.0010001, -0.0010001, 0.0000099999, -0.0000099999 };
            var ans = new[] { 0, 3.14159265, 3.14159265, 1.00001, 1.00001, 9.9999999999, 9.9999999999, 1.0001000, 1.0001000, 9.9999000000, 9.9999000000 };
            for (int i = 0; i < vals.Length; i++)
            {
                var result = MathEx.Normalize(vals[i]);
                Assert.AreEqual(result, ans[i], $"Expected for '{ans[i]}': false, Actual:{result}");
            }
        }

        [TestMethod]
        public void TestHeadValue()
        {
            var vals = new[] { 0, 3.14159265, -3.14159265, 1000.01, -1000.01, 999.99999999, -999.99999999, 0.0010001, -0.0010001, 0.0000099999, -0.0000099999 };
            var ans = new[] { 0, 31, 31, 10, 10, 99, 99, 10, 10, 99, 99 };
            for (int i = 0; i < vals.Length; i++)
            {
                var result = MathEx.HeadValue(vals[i], 2);
                Assert.AreEqual(result, ans[i], $"Expected for '{ans[i]}': false, Actual:{result}");
            }
        }

        [TestMethod]
        public void TestSignificantDigits()
        {
            var vals = new[] { 0, 3.14159265, -3.14159265, 1000.01, -1000.01, 999.99999999, -999.99999999, 0.0010001, -0.0010001, 0.0000099999, -0.0000099999 };
            var ans = new[] { 0, 9, 9, 6, 6, 11, 11, 5, 5, 5, 5 };
            for (int i = 0; i < vals.Length; i++)
            {
                var result = MathEx.SignificantDigits(vals[i]);
                Assert.AreEqual(result, ans[i], $"Expected for '{ans[i]}': false, Actual:{result}");
            }
        }

        [TestMethod]
        public void TestDigit()
        {
            var vals = new[] { 0, 3.14159265, -3.14159265, 1000.01, -1000.01, 999.99999999, -999.99999999, 0.0010001, -0.0010001, 0.0000099999, -0.0000099999 };
            var ans = new[] { 0, 0, 0, 3, 3, 2, 2, -3, -3, -6, -6 };
            for (int i = 0; i < vals.Length; i++)
            {
                var result = MathEx.Digit(vals[i]);
                Assert.AreEqual(result, ans[i]);
            }
        }

        [TestMethod()]
        public void TrimUpTest2()
        {
            double val = -0.003048;
            double ans = -0.0031;
            double res = TrimUp(val, 2);
            Assert.AreEqual(res, ans
                        , $"{Environment.NewLine}"
                        + $"input:{val} answer:{ans} actual:{res}");
        }

        [TestMethod()]
        public void HeadvalueTest2()
        {
            double val = -0.003048;
            int ans = 31;
            var res = HeadValue(TrimUp(val, 2), 2);
            Assert.AreEqual(res, ans
                        , $"{Environment.NewLine}"
                        + $"input:{val} answer:{ans} actual:{res}");
        }

        [TestMethod()]
        public void NormalizeTest2()
        {
            double val = -0.0031;
            double ans = 3.1;
            var res = Normalize(val);
            Assert.AreEqual(res, ans
                        , $"{Environment.NewLine}"
                        + $"input:{val} answer:{ans} actual:{res}");
        }
    }
}
