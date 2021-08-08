using System;
using System.IO;

namespace ConsoleCalc
{
    class Laucher
    {
        
        private static TextWriter errorWriter = Console.Error;
        private static bool problem = false;
        public static void Start()
        {
            System.Console.WriteLine("ConsoleCalc 1.0");
            supportedFunctionsList();
            while(!problem) RunCalculator();
        }
        static void RunCalculator()
        {
            while(!problem)
            {  
                try
                {                                    
                    string source = Console.ReadLine();
                    Scanner scan = new Scanner(source);
                    Parser parsedScan = new Parser(scan.scanTokens());
                    Console.WriteLine($"={parsedScan.result}\n");
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
        static void supportedFunctionsList()
        {
            System.Console.WriteLine("Supported functions:");
            System.Console.WriteLine("- Addition/Subtraction\n- Multiplication/Division\n- Actions in parentheses\n");
        }
    }
}