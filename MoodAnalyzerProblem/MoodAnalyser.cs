using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
   public class MoodAnalyser
    {
        public string message;

        public MoodAnalyser()
        {
        }

        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {
            try
            {
                if (message.Equals(string.Empty))
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty");
                }
                if (message.ToUpper().Contains("SAD"))
                {
                    Console.WriteLine("Your current mood is: Sad Mood");
                    return "Sad Mood";
                }
                else
                {
                    Console.WriteLine("Your current mood is: Happy Mood");
                    return "Happy Mood";
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be null");
            }
            catch (MoodAnalyserCustomException exception)
            {
                Console.WriteLine(exception.Message);
                return exception.Message;
            }

        }
    }
}
