using System;
using JetBrains.Annotations;

namespace OrionShock.Extensions
{
    internal static class TypeExtensions
    {
        /// <summary>
        ///     Returns the default value for a type.
        /// </summary>
        /// <param name="type">The type, which must not be <see langword="null" />.</param>
        /// <returns>The default value for the type.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="type" /> is <see langword="null" />.</exception>
        [CanBeNull]
        public static object GetDefaultValue([NotNull] this Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}