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
}   }
