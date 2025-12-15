using System.Text.RegularExpressions;

namespace eb7461u20221e646.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

public static partial class StringExtensions
{
    /// <summary>
    ///     Converts a string to kebab-case.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The string in kebab-case.</returns>
    public static string ToKebabCase(this string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;
        return KebabCaseRegex().Replace(text, "-$1").Trim().ToLower();
    }

    /// <summary>
    ///     Gets the regex pattern for converting to kebab-case.
    /// </summary>
    /// <returns>The compiled regex for kebab-case conversion.</returns>
    [GeneratedRegex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", RegexOptions.Compiled)]
    private static partial Regex KebabCaseRegex();
}