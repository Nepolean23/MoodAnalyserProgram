using MoodAnalyzerProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unittest1
{
    [TestClass]
    public class HandleExpectionTest
    {
        [TestClass]
        public class Tests
        {
            HandleExpection handleExpection;
            [TestMethod]
            public void Setup()
            {
                handleExpection = new HandleExpection();
            }
            /// <summary>
            /// TC1.1 Given “I am in Sad Mood” message Should Return SAD
            /// </summary>
            [TestMethod]
            public void GivenMessage_WhenSad_ShouldReturnSadParameterLess_Constructor()
            {
                //Arrange
                handleExpection = new HandleExpection();
                string msg = "I am in SAD mood";
                //Act
                string message = handleExpection.AnalyseMoodWithoutConstructor(msg);
                //Assert
                Assert.AreEqual("SAD", message);
            }
            /// <summary>
            /// TC1.2 Given “I am in Any Mood” message Should Return HAPPY
            /// </summary>
            [TestMethod]
            public void GivenMessage_WhenAnyMood_ShouldReturnHappyParameterLess_Constructor()
            {
                handleExpection = new HandleExpection();
                string msg = "I am in Any mood";
                string message = handleExpection.AnalyseMoodWithoutConstructor(msg);
                Assert.AreEqual("HAPPY", message);
            }
            /// <summary>
            /// TC1.1 Given “I am in Sad Mood” message in Constructor Should Return SAD
            /// </summary>
            [TestMethod]
            public void GivenMessage_WhenSad_ShouldReturnSad()
            {
                handleExpection = new HandleExpection("I am in Sad mood");
                string message = handleExpection.AnalyseMood();
                Assert.AreEqual("SAD", message);
            }
            /// <summary>
            /// TC1.2 Given “I am in Happy Mood” message in Constructor Should Return SAD
            /// </summary>
            [TestMethod]
            public void GivenMessage_WhenHappy_ShouldReturnHappy()
            {
                handleExpection = new HandleExpection("I am in Happy mood");
                string message = handleExpection.AnalyseMood();
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
                handleExpection = new HandleExpection();
                string message = handleExpection.AnalyseMood();
                Assert.AreEqual("HAPPY", message);
            }

        }

    }
}
