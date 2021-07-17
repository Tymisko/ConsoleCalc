using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ConsoleCalc.Tests")] // allows internal class to being tested.

namespace ConsoleCalc
{
    internal class Actions 
    {
        public static double Sum(List<double> numbers)
        {
            double sum = 0.0;
            foreach(var number in numbers)
            {
                sum += number;
            }
            return sum;
        }
        public static double Difference(List<double> numbers)
            {
                double difference = numbers[0];
                for(var i = 1; i < numbers.Count; i++)
                {
                    difference -= numbers[i];
                }
                return difference;
            } 
        // public static double Product(List<double> numbers)
        // {
        //     double multiplication;
        // }
    }
}
