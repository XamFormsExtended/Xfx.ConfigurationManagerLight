using FluentAssertions;
using NUnit.Framework;
using Xfx;

namespace Tests
{
    [TestFixture]
    public class ConfigurationManagerLightTests
    {
        [SetUp]
        public void SetUp()
        {
            ConfigurationManagerLightBootstrapper.Init();
        }

        [Test]
        public void ShouldGetValuesFromConfig()
        {
            // setup

            // execute

            // assert
            ConfigurationManagerLight.AppSettings["foo"].Should().Be("my foo");
            ConfigurationManagerLight.AppSettings["bar"].Should().Be("my bar");
            ConfigurationManagerLight.AppSettings.Count.Should().Be(2);
        }
    }
}
