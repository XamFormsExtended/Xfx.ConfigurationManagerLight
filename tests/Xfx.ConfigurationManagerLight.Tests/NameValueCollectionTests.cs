using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Xfx;

namespace Tests
{
    [TestFixture]
    public class NameValueCollectionTests
    {
        [Test]
        public void ShouldCreateNewNameValueCollection()
        {
            // setup
            var kp1 = new KeyValuePair<string, string>("foo", "my foo");
            var kp2 = new KeyValuePair<string, string>("bar", "my bar");
            var list = new List<KeyValuePair<string, string>> {kp1, kp2};

            // execute
            var nvc = new NameValueCollection(list);

            // assert
            nvc["foo"].Should().Be("my foo");
            nvc["bar"].Should().Be("my bar");
            nvc.Count.Should().Be(2);
            nvc.AllKeys.Should().BeEquivalentTo("foo", "bar");
        }
    }
}