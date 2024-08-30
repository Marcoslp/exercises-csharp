using System.Text.Json;
using C_sharp_exercises.Logger;
using C_sharp_exercises.Logger.Models;

class Program
{
    static void Main()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logger", "Data", "logsEntry.json");
        Random random = new();
        int randomNumber = random.Next(100, 400);

        string outputFile = "application.log";
        string jsonString = File.ReadAllText(filePath);
        List<LogEntry>? logEntries = JsonSerializer.Deserialize<List<LogEntry>>(jsonString);

        if (logEntries != null)
        {
            foreach (var entry in logEntries)
            {
                Logger.Log_message(outputFile, entry.ErrorMessage, entry.Flag);
                Thread.Sleep(randomNumber);
            }
        }
        else
        {
            Console.WriteLine("An error ocurred while reading input data");
        }

        Logger.OpenFileContent(outputFile);
    }
}