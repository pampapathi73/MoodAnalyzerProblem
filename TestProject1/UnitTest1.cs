using MoodAnalyzerProblem;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void SadMoodTest()
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in sad mood");
            string expected = "Sad Mood";
            //Act
            string actual = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void HappyMoodTest()
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in any mood");
            string expected = "Happy Mood";
            //Act
            string actual = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);


        }
        [Test]
        public void NullMessageTest()
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser(null);
            string expected = "Happy Mood";
            //Act
            string actual = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GivenNullUsingCustomException()
        {
            try
            {
                //Arrange
                MoodAnalyser moodAnalyser = new MoodAnalyser(null);
                //Act
                string actual = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("Mood should not be null", exception.Message);
            }
        }

        [Test]
        public void GivenEmptyUsingCustomException()
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser("");
            string expected = "Mood should not be empty";
            //Act
            string actual = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        /// UC 4.1 : Given moodAnalyser class name should create moodAnalyser object with default constructor
        /// </summary>
        [Test]
        public void GivenMoodAnalyserClassName_ShouldReturnMoodAnalyserObject()
        {
            //Arrange
            var expected = new MoodAnalyser("");
            //Act
            object result = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser", null); ;
            //Assert
            expected.Equals(result);
        }

        /// <summary>
        /// UC 4.2 : Given an improper class name should throw mood analysis exception.
        /// </summary>
        [Test]
        public void GivenImproperClassName_ShouldThrowMoodAnalysisException()
        {
            try
            {
                //Act
                object result = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyzerProblemDifferent.MoodAnalyser", "MoodAnalyser",null);
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("Exception: class not found", exception.Message);
            }
        }

        /// <summary>
        /// UC 4.3 : Given an improper constructor name should throw mood analysis exception.
        /// </summary>
        [Test]
        public void GivenImproperConstructorName_ShouldThrowMoodAnalysisException()
        {
            try
            {
                //Act
                object result = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyserDifferent" ,null);
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("Exception: constructor not found in the class", exception.Message);
            }
        }
        /// UC 5.1 : Given mood analyser class name and message should create mood analyser parameterized object.
        /// </summary>
        [Test]
        public void GivenMoodAnalyserClassNameAndMessage_ReturnMoodAnalyserParameterizedObject()
        {
            //Arrange
            var expected = new MoodAnalyser("happy");
            //Act
            object result = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser", "happy");
            //Assert          
            expected.Equals(result);
        }

        /// <summary>
        /// UC 5.2 : Given an improper class name should throw mood analysis exception.
        /// </summary>
        [Test]
        public void UC5GivenImproperClassName_ShouldThrowMoodAnalysisException()
        {
            try
            {
                //Act
                object result = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyzerProblemDifferent.MoodAnalyser", "MoodAnalyser", "happy");
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("Exception: class not found", exception.Message);
            }
        }

        /// <summary>
        /// UC 5.3 : Given an improper constructor name should throw mood analysis exception.
        /// </summary>
        [Test]
        public void UC5GivenImproperConstructorName_ShouldThrowMoodAnalysisException()
        {
            try
            {
                //Act
                object result = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyserDifferent", "happy");
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("Exception: constructor not found", exception.Message);
            }

        }
        /// UC 6.1 : Given 'Happy' message when proper should return 'Happy Mood'.
        /// </summary>
        [Test]
        public void GivenHappyMessage_InvokeAnalyseMoodMethod_ShouldReturnHappyMoodMessage()
        {
            //Arrange
            string expected = "Happy Mood";
            //Act
            string actual = MoodAnalyserFactory.InvokeAnalyseMood("Happy", "AnalyseMood");
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// UC 6.2 : Given Improper method name must return mood analyser custom exception
        /// </summary>
        [Test]
        public void GivenHappyMessage_WhenImproperMethod_ShouldThrowMoodAnalysisException()
        {
            try
            {
                //Act
                object result = MoodAnalyserFactory.InvokeAnalyseMood("Happy", "AnalyseMoodDifferent");
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("Exception: method not found", exception.Message);
            }
        }

    }

}