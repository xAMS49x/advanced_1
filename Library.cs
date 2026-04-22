using System.Text;

namespace Library
{
    public class Library
    {
        // Getters
        public static string GetString(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine() ?? throw new InvalidOperationException("Null exception occured.");
        }

        public static int GetInt(string msg)
        {
            return Convert.ToInt32(GetString(msg));
        }

        public static double GetDouble(string msg)
        {
            return Convert.ToDouble(GetString(msg));
        }

        public static byte GetBytes(string msg)
        {
            return Convert.ToByte(GetString(msg));
        }

        // Validations
        public static bool ValidateStringLength(string text, int minLength, int maxLength)
        {
            if (text.Trim().Length < minLength || text.Trim().Length > maxLength)
            {
                return true;
            }

            return false;
        }

        public static bool ValidateRange(byte value, int min, int max)
        {
            if (value < min || value > max)
            {
                return false;
            }

            return true;
        }

        // Task-specific functions
        public static int CoinFlip()
        {
            var coinToss = new Random();
            int roll = coinToss.Next(1, 1001);
            switch (roll)
            {
                case int n when n <= 500:
                    return 0;
                default:
                    return 1;
            }
        }

        // Logging functions

        private static StringBuilder log = new StringBuilder();

        public static void Log(string message)
        {
            Console.WriteLine(message);
            log.AppendLine($" {message}");
        }

        public static string Ask(string prompt)
        {
            Console.WriteLine(prompt);
            log.Append($" {prompt}");
            string input = Console.ReadLine()!;
            log.AppendLine();
            log.AppendLine($" {input}");
            return input;
        }

        public static void SaveLog(int exitCode = 0)
        {
            log.AppendLine($"\nProcess finished with exit code {exitCode}");
            string fileName = $"log_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt";
            string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            File.WriteAllText(path, log.ToString());
            Console.WriteLine($"\nLog saved to: {path}");
        }
    }
}