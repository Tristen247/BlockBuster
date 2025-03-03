using System;
using BlockBuster;
using System.Collections.Generic;
using BlockBusterConsole;
using BlockBuster.Models;

/*
var b = BlockBusterBasicFunctions.GetAllMovies();
var oh = new OutputHelper();
oh.WriteToCSV(b);
*/

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2) // 2 args required
        {
            Console.WriteLine("Usage:BlockBusterConsole.exe <OutputType> <MethodName> [Parameter]");
            return;
        }

        string outputType = args[0]; // "Console" or "CSV"
        string methodName = args[1]; // Ex. GetMovieByTitle
        string parameter = args.Length > 2 ? args[2] : null; //

        OutputHelper oh = new OutputHelper();
        List<Movie> result = new List<Movie>();

        using (var db = new Se407BlockBusterContext())
        {
            switch (methodName)
            {

                case "GetMovieByTitle":
                    if (string.IsNullOrWhiteSpace(parameter))
                    {
                        Console.WriteLine("Error: Missing movie title.");
                        return;
                    }
                    var movie = db.Movies.FirstOrDefault(m => m.Title == parameter);
                    if (movie != null) result.Add(movie);
                    break;

                case "GetAllMovies":
                    result = db.Movies.ToList();
                    break;

                default:
                    Console.WriteLine("Error: Unknown method name.");
                    return;
            }
        }

        if (outputType.Equals("CSV"))
        {
            oh.WriteToCSV(result);
            oh.WriteToConsole("Output written to: file.csv");
        }
        else if (outputType.Equals("Console"))
        {
            oh.WriteToConsole(result);
        }
        else
        {
            Console.WriteLine("Error: Invalid output type. Please type 'CSV' or 'Console.'");
        }
    }
}







