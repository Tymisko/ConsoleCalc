using System;
using System.IO;

namespace ConsoleCalc
{
    class Laucher
    {
        
        private static TextWriter errorWriter = Console.Error;
        private static bool problem = false;
        public static void StartProgram()
        {
            System.Console.WriteLine("ConsoleCalc 1.05");
            printInstructions();
            while(!problem) RunCalculator();
        }
        private static void RunCalculator()
        {
            while(!problem)
            {  
                try
                {   
                    System.Console.Write("Enter math operation: ");                       
                    string source = Console.ReadLine();
                    Scanner scan = new Scanner(source);
                    Parser parsedScan = new Parser(scan.scanTokens());
                    Console.Write($"={parsedScan.result}\n\n");
                }
                catch(ArgumentException)
                {
                    errorWriter.WriteLine("Unexpected character. Try Again.");
                }
                catch(DivideByZeroException)
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
        private static void printInstructions()
        {
            System.Console.WriteLine("Supported actions:\n- Addition '+'\n- Subtraction '-'\n- Multiplication '*'\n- Division '/' or ':'\n- Raising to power '^'\n- Actions in parentheses and braces '('action')' or '{'action'}'");
            System.Console.WriteLine("\nUsage: Enter mathematical operation and press enter.\n");
        }
    }
}