using System;
using System.Text;

namespace OrionShock.Extensions
{
    /// <summary>
    ///     Provides extension methods for the <see cref="string" /> type.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        ///     Splits a <c>camelCase</c> or <c>PascalCase</c> string into a space separated string.
        /// </summary>
        /// <param name="source">The input string.</param>
        /// <returns>A space separated string.</returns>
        public static string SplitPascalCase(this string source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var span = source.AsSpan();
            var builder = new StringBuilder();
            var start = 0;
            for (var i = 1; i < span.Length; ++i)
            {
                if (span[i] < 'A' || span[i] > 'Z')
                {
                    continue;
                }

                builder.Append(span[start..i]);
                builder.Append(' ');
                start = i;
            }

            builder.Append(span[start..]);
            return builder.ToString();
        }
    }
}