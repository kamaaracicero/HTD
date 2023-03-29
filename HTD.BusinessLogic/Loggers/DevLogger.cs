using System;
using System.IO;
using System.Text;

namespace HTD.BusinessLogic.Loggers
{
    public static class DevLogger
    {
        public const string LogView = "{0}{1}:[{2}][{3}] {4}";
        public const string FileName = "dev_log.txt";

        public static void AddLog(string message, int stage, LogClass logClass, LogItem logItem)
        {
            if (!File.Exists(FileName))
                File.Create(FileName).Close();

            using (StreamWriter writer = new StreamWriter(FileName, true))
                writer.WriteLine(string.Format(LogView,
                    GetTab(stage),
                    DateTime.Now.ToString(),
                    logClass.ToString(),
                    logItem.ToString(),
                    message));
        }

        private static string GetTab(int stage)
        {
            StringBuilder @string = new StringBuilder();
            for (int i = 0; i < (stage * 2); i++)
                @string.Append(' ');

            return @string.ToString();
        }
    }
}
