using System;

namespace SafeHaven
{
    /// <summary>
    /// The main class and entry point of the application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The entry point of the application.
        /// </summary>
        /// <param name="args">An array of command-line arguments.</param>
        static void Main(string[] args)
        {
            Safehaven safeHaven = new Safehaven();

            Console.WriteLine(safeHaven.Title);
            Console.ReadLine();
        }
    }
}
