using System;
using System.Collections.Generic;

namespace ConsoleCalc
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = new List<double>(){1,2,3};
            Actions.Divide(numbers);
        }
    }
}
