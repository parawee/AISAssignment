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
            int[] inputC_B = new int[2] {1,1};
            int[] inputB_A = new int[2] {1,1 };
            int[] inputOr = new int[2] {0, 0 };

            int[] outputExpectC_B = new int[2] { 0, 1 };
            int[] outputExpectB_A = new int[2] { 0, 1 };
            int[] outputTest = new int[2];
            int[] outputExpect = new int[2] { 0, 1 };

             var oHalfAdder = new HalfAdder();
            int[] outputC_B = oHalfAdder.ExecuteAdder(inputC_B);
            Assert.AreEqual(outputExpectC_B[0], outputC_B[0]);
            Assert.AreEqual(outputExpectC_B[1], outputC_B[1]);


            int[] outputB_A = oHalfAdder.ExecuteAdder(inputB_A);
            Assert.AreEqual(outputExpectB_A[0], outputB_A[0]);
            Assert.AreEqual(outputExpectB_A[1], outputB_A[1]);

            var oGate = new OrGate();
            oGate.Input = inputOr;
            outputTest[0]= oGate.Operate();
            outputTest[1] = outputB_A[1];

            Assert.AreEqual(outputTest[0], outputExpect[0]);
            Assert.AreEqual(outputTest[1], outputExpect[1]);

        }
        public void TestMethod1()
        {
        }
    }
}
