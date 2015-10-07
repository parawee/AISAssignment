using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIS_AssignmentONE
{
    public interface IExecuteAdder
    {
        int[] ExecuteAdder(int[] x);
    }

    public interface IGateOperate
    {
        int Operate();
    }

    public abstract class Gate
    {
        public int[] Input;
        public int InputSingle;
    }

    public class AndGate : Gate, IGateOperate
    {
        public int Operate()
        {
            return Input[0] * Input[1];
        }
    }

    public class OrGate : Gate, IGateOperate
    {
        public int Operate()
        {
            if (Input[0] == Input[1] && Input[0] == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }

    public class InvGate : Gate, IGateOperate
    {
        public int Operate()
        {
            return InputSingle ^= 1;
        }
    }

    public class HalfAdder : IExecuteAdder
    {
        public int[] ExecuteAdder(int[] x)
        {
            int[] result = new int[2];
            int[] temp = new int[2];

            var oOr = new OrGate();
            oOr.Input = x;
            result[0] = oOr.Operate();

            var oAnd = new AndGate();
            oAnd.Input = x;
            result[1] = oAnd.Operate();

            temp[0] = result[0];

            var oInv = new InvGate();
            oInv.InputSingle = result[1];
            temp[1] = oInv.Operate();

            oAnd.Input = temp;
            result[0] = oAnd.Operate();
            return result;
        }
    }

    public class FullAdder : IExecuteAdder
    {
        public int[] ExecuteAdder(int[] x)
        {
            int[] result = new int[2];
            int[] Input = new int[2];
            int[] Output = new int[2];

            Input[0] = x[0];
            Input[1] = x[1];
            var oHalfAdd = new HalfAdder();
            Output = oHalfAdd.ExecuteAdder(Input);
            result[0] = Output[0];

            Input[0] = Output[1];
            Input[1] = x[2];
            Output = oHalfAdd.ExecuteAdder(Input);
            result[1] = Output[1];

            Input[0] = result[0];
            Input[1] = Output[0];
            var oOr = new OrGate();
            oOr.Input = Input;
            result[0] = oOr.Operate();
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] result = new int[2];

            Console.WriteLine("*********************************************************");
            Console.WriteLine("                    ASSIGNMENT ONE                       ");
            Console.WriteLine("*********************************************************");

            Console.WriteLine("==================== HALF ADDER (HA) ====================");
            IExecuteAdder oHalfAdder = new HalfAdder();
            var halfAdder = new int[] { 1, 1 };
            result = oHalfAdder.ExecuteAdder(halfAdder);
            PrintResult(halfAdder, result);

            halfAdder = new int[] { 1, 0 };
            result = oHalfAdder.ExecuteAdder(halfAdder);
            PrintResult(halfAdder, result);

            halfAdder = new int[] { 0, 1 };
            result = oHalfAdder.ExecuteAdder(halfAdder);
            PrintResult(halfAdder, result);

            halfAdder = new int[] { 0, 0 };
            result = oHalfAdder.ExecuteAdder(halfAdder);
            PrintResult(halfAdder, result);

            Console.WriteLine("=========================================================");
            Console.WriteLine("==================== FULL ADDER (FA) ====================");
            var fullAdder = new int[] { 0, 0, 0 };
            IExecuteAdder oFullAdder = new FullAdder();
            result = oFullAdder.ExecuteAdder(fullAdder);
            PrintResult(halfAdder, result);

            fullAdder = new int[] { 0, 0, 1 };
            result = oFullAdder.ExecuteAdder(fullAdder);
            PrintResult(fullAdder, result);

            fullAdder = new int[] { 0, 1, 0 };
            result = oFullAdder.ExecuteAdder(fullAdder);
            PrintResult(fullAdder, result);

            fullAdder = new int[] { 1, 0, 0 };
            result = oFullAdder.ExecuteAdder(fullAdder);
            PrintResult(fullAdder, result);

            fullAdder = new int[] { 0, 1, 1 };
            result = oFullAdder.ExecuteAdder(fullAdder);
            PrintResult(fullAdder, result);

            fullAdder = new int[] { 1, 0, 1 };
            result = oFullAdder.ExecuteAdder(fullAdder);
            PrintResult(fullAdder, result);

            fullAdder = new int[] { 1, 1, 0 };
            result = oFullAdder.ExecuteAdder(fullAdder);
            PrintResult(fullAdder, result);

            fullAdder = new int[] { 1, 1, 1 };
            result = oFullAdder.ExecuteAdder(fullAdder);
            PrintResult(fullAdder, result);

            Console.WriteLine("=========================================================");


            Console.WriteLine("*********************************************************");
            Console.WriteLine("                    ASSIGNMENT TWO                       ");
            Console.WriteLine("*********************************************************");

            double x = 0.00;

            Console.WriteLine("###Exit Console by type 'exit'###"); // Prompt
            Console.WriteLine("Enter input Sqrt:"); // Prompt
            string line = Console.ReadLine(); // Get string from user
            if (line == "exit") // Check string
            {
                Environment.Exit(0);
            }
            else
            {
                try
                {
                    x = Convert.ToDouble(line);
                    double output = Sqrt(x);
                    Console.WriteLine(output.ToString("#.0000"));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            Console.WriteLine("Press Any key to Exit");
            Console.ReadLine();
        }

        private static void PrintResult(int[] input, int[] output)
        {
            if (input.Length == 2)
            {
                Console.WriteLine(String.Format("input a [{0}] , input b [{1}], output s = [{2}] ,output c = [{3}]", input[0], input[1], output[0], output[1]));
            }
            else
            {
                Console.WriteLine(String.Format("input a [{0}] , input b [{1}] , input c [{2}] , output c = [{3}] ,output s = [{4}]", input[0], input[1], input[2], output[0], output[1]));
            }
        }

        private  static double Sqrt(double x)
        {
            double est = 1.00;
            double quatient, mean = 0.00;
            Console.WriteLine("Estimate ||     Quatient ||  Mean");
            Console.WriteLine("=======================================");
            try
            {
                do
                {
                    quatient = (x / est);
                    mean = (quatient + est) / 2;

                    Console.WriteLine(String.Format("{0}   ||    {1}    ||    {2}", est.ToString("#.0000"), quatient.ToString("#.0000"), mean.ToString("#.0000")));
                    est = mean;

                } while ((Math.Abs(est * est - x) / x) > 0.001);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("=======================================");

            return est;
        }

    }
}
