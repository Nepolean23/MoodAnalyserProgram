using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyzerProgram
{
    public class MoodAnalysisFactoryUsingReflection
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
                    throw new CustomExpectionUsingReflection(CustomExpectionUsingReflection.ExceptionType.NO_SUCH_CLASS, "class not found");
                }
            }
            else
            {
                throw new CustomExpectionUsingReflection(CustomExpectionUsingReflection.ExceptionType.NO_SUCH_METHOD, "constructor not found");
            }
        }




    }
}
