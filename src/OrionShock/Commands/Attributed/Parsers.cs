using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using OrionShock.Extensions;

namespace OrionShock.Commands.Attributed {
    /// <summary>
    ///     Represents a collection of parsers. This class is a singleton.
    /// </summary>
    public sealed class Parsers {
        private static readonly Lazy<Parsers> _instance = new Lazy<Parsers>(() => new Parsers());

        private static readonly IDictionary<Type, Func<string, object>> PrimitiveParsers =
            new Dictionary<Type, Func<string, object>> {
                [typeof(bool)] = s => bool.Parse(s),
                [typeof(byte)] = s => byte.Parse(s),
                [typeof(sbyte)] = s => sbyte.Parse(s),
                [typeof(short)] = s => short.Parse(s),
                [typeof(ushort)] = s => ushort.Parse(s),
                [typeof(int)] = s => int.Parse(s),
                [typeof(uint)] = s => uint.Parse(s),
                [typeof(long)] = s => long.Parse(s),
                [typeof(ulong)] = s => ulong.Parse(s),
                [typeof(char)] = s => char.Parse(s)
            };

        private readonly IDictionary<Type, Func<string, object>>
            _parsers = new Dictionary<Type, Func<string, object>>();

        /// <summary>
        ///     Gets the <see cref="Parsers" /> instance.
        /// </summary>
        public static Parsers Instance => _instance.Value;

        /// <summary>
        ///     Adds a parser for the specified type.
        /// </summary>
        /// <param name="type">The type, which must not be <see langword="null" />.</param>
        /// <param name="parser">The parser, which must not be <see langword="null" />.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="type" /> or <paramref name="parser" /> is
        ///     <see langword="null" />.
        /// </exception>
        public void AddParser([NotNull] Type type, [NotNull] Func<string, object> parser) {
            if (type is null) {
                throw new ArgumentNullException(nameof(type));
            }

            _parsers[type] = parser ?? throw new ArgumentNullException(nameof(parser));
        }

        /// <summary>
        ///     Gets the parser for the specified type, or <see langword="null" /> if the parser does not exist.
        /// </summary>
        /// <param name="type">The type, which must not be <see langword="null" />.</param>
        /// <returns>The parser, or <see langword="null" /> if the parser does not exist.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="type" /> is <see langword="null" />.</exception>
        [CanBeNull]
        public Func<string, object> GetParser([NotNull] Type type) {
            if (type is null) {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsPrimitive) {
                return PrimitiveParsers[type];
            }

            return _parsers.GetValueOrDefault(type);
        }

        /// <summary>
        ///     Removes a given type's parser.
        /// </summary>
        /// <param name="type">The type, which must not be <see langword="null" />.</param>
        /// <exception cref="ArgumentNullException"><paramref name="type" /> is <see langword="null" />.</exception>
        public void RemoveParser([NotNull] Type type) {
            if (type is null) {
                throw new ArgumentNullException(nameof(type));
            }

            _parsers.Remove(type);
        }
    }
}