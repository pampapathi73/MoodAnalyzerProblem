using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyserFactory
    {
        /// <summary>
        /// UC 4 -  Added method CreateMoodAnalyserObject to create MoodAnalyser Object
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructor"></param>
        /// <returns></returns>
        public static object CreateMoodAnalyserObject(string className, string constructorName, string message)
        {
            string pattern = @"." + constructorName + "$";
            var result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    object res;
                    if (message == null)
                    {
                        res = Activator.CreateInstance(moodAnalyserType, null);
                    }
                    else
                    {
                        res = Activator.CreateInstance(moodAnalyserType, message);
                    }
                    return res;
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Exception: class not found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "Exception: constructor not found in the class");
            }
        }
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyzerProblem.MoodAnalyser");
                object moodAnalyserObject = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object mood = methodInfo.Invoke(moodAnalyserObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Exception: method not found");
            }
        }
    }
}