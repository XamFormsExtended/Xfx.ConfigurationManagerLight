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
        public void ShouldGetValuesForAppSettings()
        {
            // setup
            const string expectedFoo = "my foo";
            const string expectedBar = "my bar";

            // execute

            // assert
            ConfigurationManagerLight.AppSettings["foo"].Should().Be(expectedFoo);
            ConfigurationManagerLight.AppSettings["bar"].Should().Be(expectedBar);
            ConfigurationManagerLight.AppSettings.Count.Should().Be(2);
        }

        [Test]
        public void ShouldGetValuesForConnectionString()
        {
            // setup
            const string expectedProvider = "my provider";
            const string expectedString = "my connection string";

            // execute

            // assert
            ConfigurationManagerLight.ConnectionStrings["test"].ProviderName.Should().Be(expectedProvider);
            ConfigurationManagerLight.ConnectionStrings["test"].ConnectionString.Should().Be(expectedString);

        }
    }
}
