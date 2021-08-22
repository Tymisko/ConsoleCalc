// <copyright file="Laucher.cs" company="Jan Urbaś">
// Copyright (c) Jan Urbaś. All rights reserved.
// </copyright>

namespace ConsoleCalc
{
    using System;
    using System.IO;

    /// <summary>
    /// Laucher class contains methods that are responsible for running program and communication with user.
    /// </summary>
    public class Laucher
    {
        private static TextWriter errorWriter = Console.Error;

        private static bool problem = false;

        /// <summary>
        /// Prints instructions and runs program loop until error occurs.
        /// </summary>
        public static void StartProgram()
        {
            System.Console.WriteLine("ConsoleCalc 1.05");
            PrintInstructions();
            while (!problem)
            {
                RunCalculator();
            }
        }

        private static void RunCalculator()
        {
            while (!problem)
            {
                try
                {
                    System.Console.Write("Enter math operation: ");
                    string source = Console.ReadLine();
                    Scanner scan = new Scanner(source);
                    Parser parsedScan = new Parser(scan.ScanTokens());
                    Console.Write($"={parsedScan.Result()}\n\n");
                }
                catch (ArgumentException)
                {
                    errorWriter.WriteLine("Unexpected character. Try Again.");
                }
                catch (DivideByZeroException)
                {
                    errorWriter.WriteLine("Divide by zero. Try Again.");
                }
                finally
                {
                    problem = true;
                }
            }

            problem = false;
        }

        private static void PrintInstructions()
        {
            System.Console.WriteLine("Supported actions:\n- Addition '+'\n- Subtraction '-'\n- Multiplication '*'\n- Division '/' or ':'\n- Raising to power '^'\n- Actions in parentheses and braces '('action')' or '{'action'}'\n- Remainder '%' (ex. 125%10 is equal 5)\n- Percent of number (ex. 25%*4 is equal 1)");
            System.Console.WriteLine("\nUsage: Enter mathematical operation and press enter.\n");
        }
    }
}