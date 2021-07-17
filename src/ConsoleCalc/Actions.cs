using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ConsoleCalc.Tests")] // allows internal class to being tested.

namespace ConsoleCalc
{
    internal class Actions 
    {
        public static double Add(List<double> numbers)
        {
            double sum = 0.0;
            foreach(var number in numbers)
            {
                sum += number;
            }
            return sum;
        }
        public static double Subtract(List<double> numbers)
            {
                double difference = numbers[0];
                for(var i = 1; i < numbers.Count; i++)
                {
                    difference -= numbers[i];
                }
                return difference;
            } 
        public static double Multiply(List<double> numbers)
        {
            double product = 1;
            foreach(var number in numbers)
            {
                if(number == 0)
                {
                    return 0;
                }
                else {                    
                    product *= number;
                }
            }
            return product;
        }
        public static double Divide(List<double> numbers)
        {
            double quotient = numbers[0];
            for(var i = 1; i < numbers.Count; i++)
            {
                try
                {
                    quotient /= numbers[i];
                    if(Double.IsInfinity(quotient))
                    {
                        throw new DivideByZeroException($"Division by zero.");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);   
                }

            }
            return quotient;
        }
    }
}