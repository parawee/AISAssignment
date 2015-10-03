﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIS_AssignmentONE
{
    class Gate
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

    class HalfAdder
    {
        private int a {get;set;}
        private int b {get;set;}
        private int[] GetHalfAdder()
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
    }

    class FullAdder
    {
        private int a { get; set; }
        private int b { get; set; }
        private int c { get; set; }

        private int[] GetFullAdder()
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
            a = 1; b = 1;
            result = HalfAdder.ExecuteHalfAdder(a, b);
            Console.WriteLine(String.Format("input a [{0}] , input b [{1}], output s = [{2}] ,output c = [{3}]", a, b, result[0], result[1]));
            a = 1; b = 0;
            result = HalfAdder.ExecuteHalfAdder(a, b);
            Console.WriteLine(String.Format("input a [{0}] , input b [{1}], output s = [{2}] ,output c = [{3}]", a, b, result[0], result[1]));
            a = 0; b = 1;
            result = HalfAdder.ExecuteHalfAdder(a, b);
            Console.WriteLine(String.Format("input a [{0}] , input b [{1}], output s = [{2}] ,output c = [{3}]", a, b, result[0], result[1]));
            a = 0; b = 0;
            result = HalfAdder.ExecuteHalfAdder(a, b);
            Console.WriteLine(String.Format("input a [{0}] , input b [{1}], output s = [{2}] ,output c = [{3}]", a, b, result[0], result[1]));
            Console.WriteLine("=========================================================");



            Console.WriteLine("==================== FULL ADDER (FA) ====================");
            a = 0; b = 0; c = 0 ;
            result = FullAdder.ExecuteFullAdder(a, b, c);
            Console.WriteLine(String.Format("input a [{0}] , input b [{1}] , input c [{2}] , output c = [{3}] ,output s = [{4}]", a, b, c, result[0], result[1]));
            a = 0; b = 0; c = 1;
            result = FullAdder.ExecuteFullAdder(a, b, c);
            Console.WriteLine(String.Format("input a [{0}] , input b [{1}] , input c [{2}] , output c = [{3}] ,output s = [{4}]", a, b, c, result[0], result[1]));
            a = 0; b = 1; c = 0;
            result = FullAdder.ExecuteFullAdder(a, b, c);
            Console.WriteLine(String.Format("input a [{0}] , input b [{1}] , input c [{2}] , output c = [{3}] ,output s = [{4}]", a, b, c, result[0], result[1]));
            a = 1; b = 0; c = 0;
            result = FullAdder.ExecuteFullAdder(a, b, c);
            Console.WriteLine(String.Format("input a [{0}] , input b [{1}] , input c [{2}] , output c = [{3}] ,output s = [{4}]", a, b, c, result[0], result[1]));
            a = 0; b = 1; c = 1;
            result = FullAdder.ExecuteFullAdder(a, b, c);
            Console.WriteLine(String.Format("input a [{0}] , input b [{1}] , input c [{2}] , output c = [{3}] ,output s = [{4}]", a, b, c, result[0], result[1]));
            a = 1; b = 0; c = 1;
            result = FullAdder.ExecuteFullAdder(a, b, c);
            Console.WriteLine(String.Format("input a [{0}] , input b [{1}] , input c [{2}] , output c = [{3}] ,output s = [{4}]", a, b, c, result[0], result[1]));
            a = 1; b = 1; c = 0;
            result = FullAdder.ExecuteFullAdder(a, b, c);
            Console.WriteLine(String.Format("input a [{0}] , input b [{1}] , input c [{2}] , output c = [{3}] ,output s = [{4}]", a, b, c, result[0], result[1]));
            a = 1; b = 1; c = 1;
            result = FullAdder.ExecuteFullAdder(a, b, c);
            Console.WriteLine(String.Format("input a [{0}] , input b [{1}] , input c [{2}] , output c = [{3}] ,output s = [{4}]", a, b, c, result[0], result[1]));

            Console.WriteLine("=========================================================");


            Console.WriteLine("*********************************************************");
            Console.WriteLine("                    ASSIGNMENT TWO                       ");
            Console.WriteLine("*********************************************************");

            double est = 1.00;
            Sqrt(est);
            
            Console.ReadLine();
        }

        private  static void Sqrt(double est)
        {
            double x = 2.00;
            double quatient, mean = 0.00;
            Console.WriteLine("Estimate ||     Quatient ||  Mean");
            Console.WriteLine("=======================================");
            
            do
            {

                quatient = (x / est);
                mean = (quatient + est) / 2;
                
                Console.WriteLine(String.Format("{0}   ||    {1}    ||    {2}", est.ToString("#.0000"), quatient.ToString("#.0000"), mean.ToString("#.0000")));
                est = mean;

            } while ((Math.Abs(est * est - x) / x) > 0.001);

        }

    }
}
