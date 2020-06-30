using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileMatching
{
    class Program
    {
        private const string PathFile1 = @"C:\temp\matching\file1.csv";
        private const string PathFile2 = @"C:\temp\matching\file2.csv";
        private const string PathResult = @"C:\temp\matching\result.csv";

        static void Main(string[] args)
        {
            var linesFile1 = File.ReadAllLines(PathFile1);
            var linesFile2 = File.ReadAllLines(PathFile2);
            var resultLines = new List<string>();

            foreach (var line in linesFile2)
            {
                var lineId = line.Split(',')[0];
                if (linesFile1.Any(l => l == lineId))
                {
                    resultLines.Add(line);
                }
            }

            Console.WriteLine($"Found {resultLines.Count} matches between the two files.");
            File.WriteAllLines(PathResult, resultLines);
            Console.WriteLine($"Written to file {PathResult}.");
            Console.ReadLine();
        }
    }
}
