using System;
using System.IO;
using System.Text.RegularExpressions;

namespace HTD.BusinessLogic.Normalization
{
    internal static class PathNormalizer
    {
        private static readonly string NormalizationPattern = string.Format(@"([{0}]*\.+$)|([{0}]+)", Regex.Escape(string.Concat(new string(Path.GetInvalidPathChars()), "?", "/", "*", "\"", ":", "\\")));

        private static readonly string[] DosReservedNames = { "CON", "PRN", "AUX", "NUL", "COM0", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "LPT0", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9" };

        public static string GetNormalPath(string name)
        {
            if (Environment.OSVersion.Platform == PlatformID.Unix ||
                Environment.OSVersion.Platform == PlatformID.MacOSX)
                return name;

            const string replacement = "";

            var folder = Regex.Replace(name, NormalizationPattern, replacement);
            foreach (var reservedName in DosReservedNames)
            {
                var reservedNameWithDot = reservedName + '.';
                if (string.Equals(folder, reservedName, StringComparison.InvariantCultureIgnoreCase))
                    folder = replacement + reservedName;
                else if (folder.StartsWith(reservedNameWithDot, StringComparison.InvariantCultureIgnoreCase))
                    folder = replacement + reservedNameWithDot + folder.Remove(0, reservedNameWithDot.Length);
            }

            folder = folder.TrimEnd(' ', '.');
            if (string.IsNullOrWhiteSpace(folder))
                folder = "invalid name";

            return folder;
        }
    }
}
