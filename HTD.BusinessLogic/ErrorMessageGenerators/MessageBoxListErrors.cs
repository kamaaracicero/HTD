using System.Collections.Generic;
using System.Text;

namespace HTD.BusinessLogic.ErrorMessageGenerators
{
    public static class MessageBoxListErrors
    {
        public static string GenerateMessage(string title, IEnumerable<string> messages)
        {
            StringBuilder @string = new StringBuilder();
            @string.Append(title);
            foreach (var message in messages)
            {
                @string.Append("  - " + message);
            }

            return @string.ToString();
        }
    }
}
