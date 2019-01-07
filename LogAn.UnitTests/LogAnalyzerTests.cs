using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            
            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");
            
            Assert.False(result);
        }
        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            
            bool result = analyzer.IsValidLogFileName("filewithgoodextension.slf");
            
            Assert.True(result);
        }
        [Test]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            
            bool result = analyzer.IsValidLogFileName("filewithgoodextension.SLF");
            
            Assert.True(result);
        }
    }
}