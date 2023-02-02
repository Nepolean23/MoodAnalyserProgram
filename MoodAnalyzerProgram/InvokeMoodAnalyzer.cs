using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProgram
{
    public class InvokeMoodAnalyzer
    {
        public string message;

        public InvokeMoodAnalyzer()
        {
            Console.WriteLine("Default Constructor");
        }
        public InvokeMoodAnalyzer(string message)//constructor
        {
            this.message = message;
        }
        public string AnalyseMoodWithoutConstructor(string message)
        {
            if (message.ToLower().Contains("sad"))
                return "SAD";

            else return "HAPPY";

        }
        public string AnalyseMood() //method to analyse mood
        {
            try
            {
                if (this.message.Equals(""))
                {
                    throw new MoodAnalyzerInvokeCustomExpection(MoodAnalyzerInvokeCustomExpection.ExceptionType.EMPTY_MOOD, "Mood should not be empty");
                }
                else if (this.message.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzerInvokeCustomExpection(MoodAnalyzerInvokeCustomExpection.ExceptionType.NULL_MOOD, "Mood should not be null");
            }
        }




    }
}
