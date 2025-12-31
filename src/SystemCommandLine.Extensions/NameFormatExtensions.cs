using System.Text.RegularExpressions;

namespace SystemCommandLine.Extensions;

public static partial class NameFormatExtensions
{
    public static string ToKebabCase(string prefix, string name) => $"{prefix}{ToKebabCase(name)}";

    public static string ToKebabCase(string name) => MyRegex().Replace(name, "-$1").Trim('-').ToLower();

    [GeneratedRegex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z0-9])", RegexOptions.Compiled)]
    private static partial Regex MyRegex();
}
