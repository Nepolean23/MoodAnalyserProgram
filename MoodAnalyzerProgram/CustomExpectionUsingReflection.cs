using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProgram
{
    public class CustomExpectionUsingReflection : Exception
    {
        public ExceptionType exceptionType;
        public enum ExceptionType
        {
            NULL_MOOD,
            EMPTY_MOOD,
            NO_SUCH_CLASS,
            NO_SUCH_METHOD
        }
        public CustomExpectionUsingReflection(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }




    }
}
