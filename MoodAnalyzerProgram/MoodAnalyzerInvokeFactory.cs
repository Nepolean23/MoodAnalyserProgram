﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyzerProgram
{
    public class MoodAnalyzerInvokeFactory
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
                    Type InvokeMoodAnalyzer = executing.GetType(className);
                    return Activator.CreateInstance(InvokeMoodAnalyzer);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyzerInvokeCustomExpection(MoodAnalyzerInvokeCustomExpection.ExceptionType.NO_SUCH_CLASS, "class not found");
                }
            }
            else
            {
                throw new MoodAnalyzerInvokeCustomExpection(MoodAnalyzerInvokeCustomExpection.ExceptionType.NO_SUCH_METHOD, "constructor not found");
            }
        }
        public object CreateMoodAnalyseParameterObject(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalysisException);
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
                    throw new MoodAnalyzerInvokeCustomExpection(MoodAnalyzerInvokeCustomExpection.ExceptionType.NO_SUCH_METHOD, "could not find constructor");
                }
            }
            else
            {
                throw new MoodAnalyzerInvokeCustomExpection(MoodAnalyzerInvokeCustomExpection.ExceptionType.NO_SUCH_CLASS, "could not find class");
            }
        }
        public string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyzerInvokeCustomExpection);
                MethodInfo methodInfo = type.GetMethod(methodName);
                MoodAnalyserFactoryUsingParameterConstructor reflector = new MoodAnalyserFactoryUsingParameterConstructor();
                object moodAnalyserObject = reflector.CreateMoodAnalyseParameterObject("MoodAnalyser.MoodAnalysis", "MoodAnalysis", message);
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzerInvokeCustomExpection(MoodAnalyzerInvokeCustomExpection.ExceptionType.NO_SUCH_METHOD, "method not found");
            }
        }





    }
}
