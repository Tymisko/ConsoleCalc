// <copyright file="Program.cs" company="Jan Urbaś">
// Copyright (c) Jan Urbaś. All rights reserved.
// </copyright>

namespace ConsoleCalc
{
    /// <summary>
    /// Class that contains Main method.
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            // Laucher.StartProgram();
            Scanner scan = new Scanner("1(50*51)/50*51");
            var scannedScan = scan.ScanTokens();
            Parser parsedScan = new Parser(scannedScan);
        }
    }
}
