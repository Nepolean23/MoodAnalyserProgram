using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MoodAnalyzerProgram;

namespace MoodAnalyzerProgram
{
    public class MoodAnalyserFactoryUsingParameterConstructor
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
                    throw new CustomExpectionUsingParameterConstructor(CustomExpectionUsingParameterConstructor.ExceptionType.NO_SUCH_CLASS, "class not found");
                }
            }
            else
            {
                throw new CustomExpectionUsingParameterConstructor(CustomExpectionUsingParameterConstructor.ExceptionType.NO_SUCH_METHOD, "constructor not found");
            }
        }
        public object CreateMoodAnalyseParameterObject(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalysisFactoryUsingReflection);
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
                    throw new CustomExpectionUsingParameterConstructor(CustomExpectionUsingParameterConstructor.ExceptionType.NO_SUCH_METHOD, "could not find constructor");
                }
            }
            else
            {
                throw new CustomExpectionUsingParameterConstructor(CustomExpectionUsingParameterConstructor.ExceptionType.NO_SUCH_CLASS, "could not find class");
            }
        }
    }
}

