using MoodAnalyzerProgram;

namespace Unittest1
{
    [TestClass]
    public class Tests
    {
        SimpleMoodAnalyzerProgram moodAnalyzerProgram;
        [TestMethod]
        public void Setup()
        {
            moodAnalyzerProgram = new SimpleMoodAnalyzerProgram();
        }
        /// <summary>
        /// TC1.1 Given “I am in Sad Mood” message Should Return SAD
        /// </summary>
        [TestMethod]
        public void GivenMessage_WhenSad_ShouldReturnSadParameterLess_Constructor()
        {
            //Arrange
            moodAnalyzerProgram = new SimpleMoodAnalyzerProgram();
            string msg = "I am in SAD mood";
            //Act
            string message = moodAnalyzerProgram.AnalyseMoodWithoutConstructor(msg);
            //Assert
            Assert.AreEqual("SAD", message);
        }
        /// <summary>
        /// TC1.2 Given “I am in Any Mood” message Should Return HAPPY
        /// </summary>
        [TestMethod]
        public void GivenMessage_WhenAnyMood_ShouldReturnHappyParameterLess_Constructor()
        {
            moodAnalyzerProgram = new SimpleMoodAnalyzerProgram();
            string msg = "I am in Any mood";
            string message = moodAnalyzerProgram.AnalyseMoodWithoutConstructor(msg);
            Assert.AreEqual("HAPPY", message);
        }
        /// <summary>
        /// TC1.1 Given “I am in Sad Mood” message in Constructor Should Return SAD
        /// </summary>
        [TestMethod]
        public void GivenMessage_WhenSad_ShouldReturnSad()
        {
            moodAnalyzerProgram = new SimpleMoodAnalyzerProgram("I am in Sad mood");
            string message = moodAnalyzerProgram.AnalyseMood();
            Assert.AreEqual("SAD", message);
        }
        /// <summary>
        /// TC1.2 Given “I am in Happy Mood” message in Constructor Should Return SAD
        /// </summary>
        [TestMethod]
        public void GivenMessage_WhenHappy_ShouldReturnHappy()
        {
            moodAnalyzerProgram = new SimpleMoodAnalyzerProgram("I am in Happy mood");
            string message = moodAnalyzerProgram.AnalyseMood();
            Assert.AreEqual("HAPPY", message);
        }
    }


}