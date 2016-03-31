using System;

namespace NHLGames.AdDetection.Common
{
    public static class Utilities
    {
        public static void WriteLineWithTime(string message)
        {
            Console.WriteLine($"[{DateTime.Now}]: {message}");
        }
    }
}