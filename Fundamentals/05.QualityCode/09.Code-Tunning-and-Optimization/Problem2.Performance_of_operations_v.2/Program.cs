// NOTE: the functions Math.Sqrt, Math.Log and Math.Sin work only with double
// and if we cast the decimal or float to double, the measurement will have no meaning
// I couldnt find a way to iterate through the numeric data types in order to avoid the code repetition.

namespace Problem2.Performance_of_operations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    internal class Program
    {
        private const int OperationCount = 1000000;
        private const int Operand = 5;
        
        private static void Main(string[] args)
        {
            var tableA = new List<List<string>>();
            tableA.Add(new List<string>
            {
                "n= " + OperationCount,
                "Int",
                "Long",
                "Float",
                "Double",
                "Decimal"
            });

            //Addition
            var addition = new List<string>();
            addition.Add("Addition");
            addition.Add(CurrentOperation(x => x + x, Operand));
            addition.Add(CurrentOperation(x => x + x, (long) Operand));
            addition.Add(CurrentOperation(x => x + x, (float) Operand));
            addition.Add(CurrentOperation(x => x + x, (double) Operand));
            addition.Add(CurrentOperation(x => x + x, (decimal) Operand));
            tableA.Add(addition);

            //Subtraction
            var subtraction = new List<string>();
            subtraction.Add("Subtraction");
            subtraction.Add(CurrentOperation(x => x - x, Operand));
            subtraction.Add(CurrentOperation(x => x - x, (long) Operand));
            subtraction.Add(CurrentOperation(x => x - x, (float) Operand));
            subtraction.Add(CurrentOperation(x => x - x, (double) Operand));
            subtraction.Add(CurrentOperation(x => x - x, (decimal) Operand));
            tableA.Add(subtraction);

            //Multiplication
            var multiplication = new List<string>();
            multiplication.Add("Multiplication");
            multiplication.Add(CurrentOperation(x => x*x, Operand));
            multiplication.Add(CurrentOperation(x => x*x, (long) Operand));
            multiplication.Add(CurrentOperation(x => x*x, (float) Operand));
            multiplication.Add(CurrentOperation(x => x*x, (double) Operand));
            multiplication.Add(CurrentOperation(x => x*x, (decimal) Operand));
            tableA.Add(multiplication);

            //Division
            var division = new List<string>();
            division.Add("Division");
            division.Add(CurrentOperation(x => x/x, Operand));
            division.Add(CurrentOperation(x => x/x, (long) Operand));
            division.Add(CurrentOperation(x => x/x, (float) Operand));
            division.Add(CurrentOperation(x => x/x, (double) Operand));
            division.Add(CurrentOperation(x => x/x, (decimal) Operand));
            tableA.Add(division);

            //Incrementation ++i
            var inrementPrefix = new List<string>();
            inrementPrefix.Add("Incrementation prefix ++");
            inrementPrefix.Add(CurrentOperation(x => ++x, Operand));
            inrementPrefix.Add(CurrentOperation(x => ++x, (long) Operand));
            inrementPrefix.Add(CurrentOperation(x => ++x, (float) Operand));
            inrementPrefix.Add(CurrentOperation(x => ++x, (double) Operand));
            inrementPrefix.Add(CurrentOperation(x => ++x, (decimal) Operand));
            tableA.Add(inrementPrefix);

            //Incrementation i++
            var inrementPostfix = new List<string>();
            inrementPostfix.Add("Incrementation postfix ++");
            inrementPostfix.Add(CurrentOperation(x => x++, Operand));
            inrementPostfix.Add(CurrentOperation(x => x++, (long) Operand));
            inrementPostfix.Add(CurrentOperation(x => x++, (float) Operand));
            inrementPostfix.Add(CurrentOperation(x => x++, (double) Operand));
            inrementPostfix.Add(CurrentOperation(x => x++, (decimal) Operand));
            tableA.Add(inrementPostfix);

            //Incrementation i += 1
            var inrementShorthand = new List<string>();
            inrementShorthand.Add("Incrementation shorthand += ");
            inrementShorthand.Add(CurrentOperation(x => x += 1, Operand));
            inrementShorthand.Add(CurrentOperation(x => x += 1, (long) Operand));
            inrementShorthand.Add(CurrentOperation(x => x += 1, (float) Operand));
            inrementShorthand.Add(CurrentOperation(x => x += 1, (double) Operand));
            inrementShorthand.Add(CurrentOperation(x => x += 1, (decimal) Operand));
            tableA.Add(inrementShorthand);

            PrintTable(tableA);
            ExportToCSV(tableA,"..\\..\\tableA.csv");

            List<List<string>>tableB = new List<List<string>>();
            tableB.Add(new List<string> {"n = "+OperationCount,"Double","Float","Decimal"});

            //Square root
            var sqrt = new List<string>();
            sqrt.Add("Incrementation prefix ++");
            sqrt.Add(CurrentOperation(x => Math.Sqrt(x), (double)Operand));
            tableB.Add(sqrt);
            
            //Natural Logarithm
            var log = new List<string>();
            log.Add("Natural Logarithm");
            log.Add(CurrentOperation(x => Math.Log(x), (double)Operand));
            tableB.Add(log);

            //Sine
            var sine = new List<string>();
            sine.Add("Sine");
            sine.Add(CurrentOperation(x => Math.Log(x), (double)Operand));
            tableB.Add(sine);

            PrintTable(tableB);
            ExportToCSV(tableB,"..\\..\\tableB.csv");


        }

        private static string CurrentOperation<T>(Func<T, T> operation, T operand)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            for (var i = 0; i < OperationCount; i++)
            {
                operation(operand);
            }
            stopwatch.Stop();
            var elapsedTime = stopwatch.Elapsed.TotalMilliseconds.ToString();
            stopwatch.Reset();
            return elapsedTime;
        }

        private static void PrintTable(List<List<string>> table)
        {
            foreach (var row in table)
            {
                Console.WriteLine(string.Join(",", row));
            }
        }

        private static void ExportToCSV(List<List<string>> table, string filePath)
        {
            using (TextWriter sw = new StreamWriter(filePath))
            {
                foreach (var row in table)
                {
                    sw.WriteLine(string.Join(",", row));
                }
            }
        }
    }
}