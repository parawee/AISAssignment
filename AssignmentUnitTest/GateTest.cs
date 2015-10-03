using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AIS_AssignmentONE;

namespace AssignmentUnitTest
{
    [TestClass]
    public class GateTest
    {
        [TestMethod]
        public void ExecuteFullAdder_compareWITHHA()
        {
            int a = 1;
            int b = 1;
            int c = 1;

            int[] outputExpect = new int[2];
            outputExpect = FullAdder.ExecuteFullAdder(a, b, c);

            int[] outputC_B = HalfAdder.ExecuteHalfAdder(c, b);

            int[] outputB_A = HalfAdder.ExecuteHalfAdder(outputC_B[1], a);

            int[] outputTest = new int[2];
            outputTest[0] = Gate.OR(outputC_B[0], outputB_A[0]);
            outputTest[1] = outputB_A[1];

            Assert.AreEqual(outputTest[0], outputExpect[0]);
            Assert.AreEqual(outputTest[1], outputExpect[1]);

        }
        public void TestMethod1()
        {
        }
    }
}
