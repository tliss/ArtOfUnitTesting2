using System;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        
        private LogAnalyzer la;
        
        [SetUp]
        public void SetUp()
        {
            la = MakeAnalyzer();
        }
        
        [Test]
        public void IsValidFileName_BadExtension_ReturnsFalse()
        {
            bool result = la.IsValidLogFileName("filewithbadextension.foo");
            
            Assert.False(result);
        }
        
        [TestCase("filewithgoodextension.SLF")]
        [TestCase("filewithgoodextension.slf")]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string file)
        {
            bool result = la.IsValidLogFileName(file);
            
            Assert.True(result);
        }
        
        [Test]
        [Category("Fast tests")]
        public void IsValidFileName_EmptyFileName_Throws()
        {
            var ex = Assert.Catch<Exception>(() => la.IsValidLogFileName(""));
            
            StringAssert.Contains("filename has to be provided", ex.Message);
        }

        [Test]
        [Ignore("This test doesn't work!")]
        public void ThisTestIsBroken_NeverWorks()
        {

        }

        [TestCase("badfile.foo", false)]
        [TestCase("goodfile.slf", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string file, bool expected)
        {
            la.IsValidLogFileName(file);

            Assert.AreEqual(expected, la.WasLastFileNameValid);
        }
        
        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }
    }
}