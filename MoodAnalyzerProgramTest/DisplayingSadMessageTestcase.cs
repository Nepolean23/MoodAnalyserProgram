using MoodAnalyzerProgram;

namespace Unittest1
{
    [TestClass]
    public class DisplayingSadMessageTestcase
    {
        DisplayingSadmessage sadmessage;
        [TestMethod]
        public void Setup()
        {
            sadmessage = new DisplayingSadmessage();
        }
        /// <summary>
        /// TC1.1 Given “I am in Sad Mood” message Should Return SAD
        /// </summary>
        [TestMethod]
        public void GivenMessage_WhenSad_ShouldReturnSadParameterLess_Constructor()
        {
            //Arrange
            sadmessage = new DisplayingSadmessage();

            string msg = "I am in SAD mood";
            //Act
            string message = sadmessage.AnalyseMoodWithoutConstructor(msg);
            //Assert
            Assert.AreEqual("SAD", message);
        }
        /// <summary>
        /// TC1.2 Given “I am in Any Mood” message Should Return HAPPY
        /// </summary>
        [TestMethod]
        public void GivenMessage_WhenAnyMood_ShouldReturnHappyParameterLess_Constructor()
        {
            sadmessage = new DisplayingSadmessage();
            string msg = "I am in Any mood";
            string message = sadmessage.AnalyseMoodWithoutConstructor(msg);
            Assert.AreEqual("HAPPY", message);
        }
        /// <summary>
        /// TC1.1 Given “I am in Sad Mood” message in Constructor Should Return SAD
        /// </summary>
        [TestMethod]
        public void GivenMessage_WhenSad_ShouldReturnSad()
        {
            sadmessage = new DisplayingSadmessage("I am in Sad mood");
            string message = sadmessage.AnalyseMood();
            Assert.AreEqual("SAD", message);
        }
        /// <summary>
        /// TC1.2 Given “I am in Happy Mood” message in Constructor Should Return SAD
        /// </summary>
        [TestMethod]
        public void GivenMessage_WhenHappy_ShouldReturnHappy()
        {
            sadmessage = new DisplayingSadmessage("I am in Happy mood");
            string message = sadmessage.AnalyseMood();
            Assert.AreEqual("HAPPY", message);
        }
        //UC-2
        /// <summary>
        /// TC2.1Given Null Mood Should Return Happy To make this Test Case pass Handle
        /// NULL Scenario using try catch and return Happy
        /// </summary>
        [TestMethod]
        public void GivenMessage_WhenNull_ShouldReturnHappy()
        {
            sadmessage = new DisplayingSadmessage();
            string message = sadmessage.AnalyseMood();
            Assert.AreEqual("HAPPY", message);
        }

    }

}

