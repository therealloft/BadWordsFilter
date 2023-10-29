using BadWords;
using NUnit.Framework;

namespace BadWordsFilterTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            BadWordsFilter.AddBadwords("testword", "badworda", "badwordb");
        }

        [Test]
        public void CleanMessage()
        {
            string message = "hello how are you";
            var result = BadWordsFilter.FilterWords(message);
            Assert.AreEqual(message, result.Item2);
            Assert.IsFalse(result.Item1);
        }
        [Test]
        public void ContainsBadwordAMessage()
        {
            string message = "this message contains badworda";
            var result = BadWordsFilter.FilterWords(message);
            Assert.AreEqual("this message contains ********", result.Item2);
            Assert.IsTrue(result.Item1);
        }
        [Test]
        public void ContainsBadwordBMessage()
        {
            string message = "this message contains badwordb";
            var result = BadWordsFilter.FilterWords(message);
            Assert.AreEqual("this message contains ********", result.Item2);
            Assert.IsTrue(result.Item1);
        }
        [Test]
        public void ContainsBadwordAAndBadworkdBMessage()
        {
            string message = "this message contains badworda and badwordb";
            var result = BadWordsFilter.FilterWords(message);
            Assert.AreEqual("this message contains ******** and ********", result.Item2);
            Assert.IsTrue(result.Item1);
        }
    }
}