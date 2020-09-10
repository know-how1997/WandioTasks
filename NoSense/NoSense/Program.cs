using System;
using System.Collections.Generic;
using NoSenseLibrary.Services.NoSenseService;

namespace NoSense
{
    class Program
    {
        static void Main(string[] args)
        {

            const int NEW_RRECORD = -1;

            Console.Write("Input numbers separated by comma: ");
            var input = Console.ReadLine();

            var numbers = input.GetIntArrayFromString();

            var firstResult = numbers.ThisDoesntMakeAnySense(x => true, null); // 1. default
            WriteReport(input, firstResult);

            var secondResult = numbers.ThisDoesntMakeAnySense(x => false, () => NEW_RRECORD); // 2. new record
            WriteReport(input, secondResult);

            IEnumerable<int> nullRecords = null;
            try
            {
                nullRecords.ThisDoesntMakeAnySense(null, null); // 3. null exception
            }
            catch (ArgumentNullException e)
            {
                WriteReport("null", e.ToString());
            }
        }
        public static void WriteReport(string input, object result)
        {
            Console.WriteLine($"Input data: {input}, result: {result}");
        }
    }
}
