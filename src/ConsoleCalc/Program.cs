using System;

namespace ConsoleCalc
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("ConsoleCalc 1.0\n---");
            while(true)
            {
                try
                {                    
                    Scanner scan = new Scanner(System.Console.ReadLine());
                    Parser parsedScan = new Parser(scan.scanTokens());
                    System.Console.WriteLine($"={parsedScan.result}\n");
                }
                catch(Exception)
                {
                    Console.Read();
                }
            }
        }
    }
}
