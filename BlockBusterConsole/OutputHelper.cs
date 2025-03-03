using BlockBuster.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CsvHelper;

namespace BlockBusterConsole
{
    public class OutputHelper
    {


        public void WriteToConsole(List<Movie> movies)
        {
            Console.WriteLine("List of Movies");
            foreach (var m in movies)
            {
                Console.WriteLine($"Movie ID: {m.MovieId} Title: {m.Title} Release Year:{m.ReleaseYear}");
            }
        }

        public void WriteToCSV(List<Movie> movies)
        {
            using (var writer = new StreamWriter(@"..\file.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(movies);
            }
        }

        // Overloaded method to accept a string message
        public void WriteToConsole(string message)
        {
            Console.WriteLine(message);
        }
    }
}
