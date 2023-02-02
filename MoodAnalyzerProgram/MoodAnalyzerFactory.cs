using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static MoodAnalyzerProgram.MoodAnalyzerDynamically;

namespace MoodAnalyzerProgram
{
    public class MoodAnalyzerFactory
    {
        public object CreatemoodAnalyse(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyzerCustomExpection(MoodAnalyzerCustomExpection.ExceptionType.NO_SUCH_CLASS, "class not found");
                }
            }
            else
            {
                throw new MoodAnalyzerCustomExpection(MoodAnalyzerCustomExpection.ExceptionType.NO_SUCH_METHOD, "constructor not found");
            }
        }
        public object CreateMoodAnalyseParameterObject(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyzerFactory);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { typeof(string) });
                    var obj = constructorInfo.Invoke(new object[] { message });
                    return obj;
                }
                else
                {
                    throw new MoodAnalyzerCustomExpection(MoodAnalyzerCustomExpection.ExceptionType.NO_SUCH_METHOD, "could not find constructor");
                }
            }
            else
            {
                throw new MoodAnalyzerCustomExpection(MoodAnalyzerCustomExpection.ExceptionType.NO_SUCH_CLASS, "could not find class");
            }
        }
        public string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyzerCustomExpection);
                MethodInfo methodInfo = type.GetMethod(methodName);
                MoodAnalyzerFactory reflector = new MoodAnalyzerFactory();
                object moodAnalyserObject = reflector.CreateMoodAnalyseParameterObject("MoodAnalyser.MoodAnalysis", "MoodAnalysis", message);
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzerCustomExpection(MoodAnalyzerCustomExpection.ExceptionType.NO_SUCH_METHOD, "method not found");
            }
        }
        public string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalysisException moodAnalyzer = new MoodAnalysisException();
                Type type = typeof(MoodAnalysisException);
                FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new MoodAnalyzerCustomExpection(MoodAnalyzerCustomExpection.ExceptionType.EMPTY_MESSAGE, "message should not be null");
                }
                fieldInfo.SetValue(moodAnalyzer, message);
                return moodAnalyzer.message;
            }
            catch (NullReferenceException)
            {

                throw new MoodAnalyzerCustomExpection(MoodAnalyzerCustomExpection.ExceptionType.NO_SUCH_FIELD, "field not found");
            }
        }




    }
}
