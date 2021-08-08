using System;

namespace ConsoleCalc
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Laucher.Start();
            Scanner scan = new Scanner("2(1+3)");
            var x = scan.scanTokens();
            Parser parsedScan = new Parser(x);
            Console.WriteLine(parsedScan.result);
        }
    }
}
