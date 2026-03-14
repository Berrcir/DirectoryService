using System.Text.RegularExpressions;

namespace Shared
{
    public static class RegularExpressionsExtensions
    {
        public static Regex NonLatinSymbolsRegex = new Regex(@"[^a-zA-Z]", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    }
}
