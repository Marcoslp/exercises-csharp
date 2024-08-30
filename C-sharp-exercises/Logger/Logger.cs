using System.Diagnostics;

namespace C_sharp_exercises.Logger
{
    public class Logger
    {
        public static string GetPath(string file)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Data/{file}");
        }

        public static void Log_message(string file, string message, string flag)
        {
            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("yyyy-MM-dd HH:mm:ss"); ;

            string createText = $"[{formattedDate}] [{message}] [{flag}]" + Environment.NewLine;

            File.AppendAllTextAsync(GetPath(file), createText);
        }

        public static void OpenFileContent(string file)
        {
            string path = GetPath(file);

            if (File.Exists(path))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                });
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }
    }
}
