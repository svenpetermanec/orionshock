using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace OrionShock.Tests.Extensions {
    public sealed class IDictionaryExtensionsTests {
        [Fact]
        public void GetValueOrDefault_ReferenceType_IsCorrect() {
            var dictionary = new Dictionary<string, object> {
                ["key"] = "test"
            };

            var value = dictionary.GetValueOrDefault("key");
            var value2 = dictionary.GetValueOrDefault("key2");

            Assert.Equal("test", value);
            Assert.Null(value2);
        }
    }
}