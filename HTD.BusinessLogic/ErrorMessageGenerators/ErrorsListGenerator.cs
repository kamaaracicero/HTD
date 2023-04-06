using System.Collections.Generic;
using System.Text;

namespace HTD.BusinessLogic.ErrorMessageGenerators
{
    public static class ErrorsListGenerator
    {
        public static string GenerateMessage(string title, IEnumerable<string> messages)
        {
            StringBuilder @string = new StringBuilder();
            @string.Append(title + "\n");
            foreach (var message in messages)
            {
                @string.Append("  - " + message + "\n");
            }

            return @string.ToString();
        }
    }
}
