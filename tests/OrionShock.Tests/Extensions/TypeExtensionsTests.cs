using System;
using Xunit;
using OrionShock.Extensions;

namespace OrionShock.Tests.Extensions {
    public sealed class TypeExtensionsTests {
        [Fact]
        public void GetDefaultValue_NullType_ThrowsArgumentNullException() {
            Assert.Throws<ArgumentNullException>(() => TypeExtensions.GetDefaultValue(null));
        }
        
        [Fact]
        public void GetDefaultValue_ReferenceType_ReturnsNull() {
            Assert.Null(typeof(string).GetDefaultValue());
        }

        [Fact]
        public void GetDefaultValue_ValueType_ReturnsDefaultInstance() {
            Assert.Equal(Activator.CreateInstance(typeof(int)), typeof(int).GetDefaultValue());
        }
    }
}