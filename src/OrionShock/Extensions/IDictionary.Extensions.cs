using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace OrionShock.Extensions {
    /// <summary>
    ///     Provides extension methods for the <see cref="IDictionary{TKey,TValue}" /> type.
    /// </summary>
    internal static class IDictionaryExtensions {
        /// <summary>
        ///     Gets the value for a given key in the dictionary, or a default value if the key does not exist.
        /// </summary>
        /// <param name="dictionary">The dictionary, which must not be <see langword="null" />.</param>
        /// <param name="key">The key, which must not be <see langword="null" />.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <typeparam name="TKey">The type of key.</typeparam>
        /// <typeparam name="TValue">The value.</typeparam>
        /// <returns>A value for the given key, or a default value if the key does not exist in the dictionary.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="dictionary" /> or <paramref name="key" /> is
        ///     <see langword="null" />.
        /// </exception>
        public static TValue GetValueOrDefault<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> dictionary,
            [NotNull] TKey key, TValue defaultValue = default) where TKey : notnull {
            if (dictionary is null) {
                throw new ArgumentNullException(nameof(dictionary));
            }

            if (key is null) {
                throw new ArgumentNullException(nameof(key));
            }

            return dictionary.TryGetValue(key, out var value) ? value : defaultValue;
        }
    }
}