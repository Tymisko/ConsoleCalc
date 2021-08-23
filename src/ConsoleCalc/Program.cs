// <copyright file="Program.cs" company="Jan Urbaś">
// Copyright (c) Jan Urbaś. All rights reserved.
// </copyright>

namespace ConsoleCalc
{
    /// <summary>
    /// <see cref="Program"/> is an entry level class which contains <see cref="Program.Main(string[])"/> method responsible for running calculator. There are no arguments required because it only triggers <see cref="Laucher.StartProgram()"/> method.
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            Laucher.StartProgram();
        }
    }
}
