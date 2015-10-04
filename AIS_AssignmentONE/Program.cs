using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIS_AssignmentONE
{
    interface IExecuteAdder
    {
      int[] ExecuteAdder(int[] x);
    }

    public class Gate
    {
        public static int INV(int in1)
        {
            return in1 ^= 1;
        }
        public static int AND(int in1, int in2)
        {
            return in1 * in2;
        }
        public static int OR(int in1, int in2)
        {
            if (in1 == in2 && in1 == 0)
            {
                return 0;
            }
            else
            {
               return 1;
            }
        }
    }

    public class HalfAdder : IExecuteAdder
    {
        public int a { get; set; }
        public int b { get; set; }

        public int[] GetHalfAdder()
        {
            int[] output = new int[2];

            // process s
            output[0]= Gate.AND(Gate.OR(a,b),Gate.INV(Gate.AND(a,b)));
            // process c
            output[1]= Gate.AND(a,b);

            return output;
        }

        public static int[] ExecuteHalfAdder(int a, int b)
        {
            int[] result = new int[2];
            HalfAdder oHalfAdder = new HalfAdder();
            oHalfAdder.a = a;
            oHalfAdder.b = b;
            result = oHalfAdder.GetHalfAdder();
            return result;
        }

        public int[] ExecuteAdder(int[] x)
        {
            int[] result = new int[2];
            HalfAdder oHalfAdder = new HalfAdder();
            oHalfAdder.a = x[0];
            oHalfAdder.b = x[1];
            result = oHalfAdder.GetHalfAdder();
            return result;
        }
    }

    public class FullAdder : IExecuteAdder
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }

        public int[] GetFullAdder()
        {
            int[] output = new int[2];
            // process 
            output[0] = Gate.OR(HalfAdder.ExecuteHalfAdder(c, b)[0],
                                                                    HalfAdder.ExecuteHalfAdder(
                                                                            HalfAdder.ExecuteHalfAdder(c, b)[1]
                                                                            ,a)[0]
                               );

            output[1] = HalfAdder.ExecuteHalfAdder(
                       HalfAdder.ExecuteHalfAdder(c, b)[1], a)[1];

            return output;
        }

        public static int[] ExecuteFullAdder(int a, int b, int c)
        {
            int[] result = new int[2];
            FullAdder oFullAdder = new FullAdder();
            oFullAdder.a = a;
            oFullAdder.b = b;
            oFullAdder.c = c;
            result = oFullAdder.GetFullAdder();
            return result;
        }

        public int[] ExecuteAdder(int[] x)
        {
            int[] result = new int[2];
            FullAdder oFullAdder = new FullAdder();
            oFullAdder.a = x[0];
            oFullAdder.b = x[1];
            oFullAdder.c = x[2];
            result = oFullAdder.GetFullAdder();
            return result;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int a, b,c;
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
            a = 0; b = 0; c = 0 ;
            var fullAdder = new int[] { 0, 0,0 };
            IExecuteAdder oFullAdder = new FullAdder();
            result = oFullAdder.ExecuteAdder(fullAdder);
            PrintResult(halfAdder, result);

            fullAdder = new int[] { 0, 0, 1 };
            result = oFullAdder.ExecuteAdder(fullAdder);
            PrintResult(halfAdder, result);

            fullAdder = new int[] { 0, 1, 0 };
            result = oFullAdder.ExecuteAdder(fullAdder);
            PrintResult(halfAdder, result);

            fullAdder = new int[] { 1, 0, 0 };
            result = oFullAdder.ExecuteAdder(fullAdder);
            PrintResult(halfAdder, result);

            fullAdder = new int[] { 0, 1, 1 };
            result = oFullAdder.ExecuteAdder(fullAdder);
            PrintResult(halfAdder, result);

            fullAdder = new int[] { 1, 0, 1 };
            result = oFullAdder.ExecuteAdder(fullAdder);
            PrintResult(halfAdder, result);

            fullAdder = new int[] { 1, 1, 0 };
            result = oFullAdder.ExecuteAdder(fullAdder);
            PrintResult(halfAdder, result);

            fullAdder = new int[] { 1, 1, 1 };
            result = oFullAdder.ExecuteAdder(fullAdder);
            PrintResult(halfAdder, result);

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
