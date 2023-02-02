using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProgram
{
    public class MoodAnalyzerDynamically
    {
        public string message;

        public MoodAnalyzerDynamically()
        {
            Console.WriteLine("Default Constructor");
        }
        public MoodAnalyzerDynamically(string message)//constructor
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
                    throw new MoodAnalyzerCustomExpection(MoodAnalyzerCustomExpection.ExceptionType.EMPTY_MOOD, "Mood should not be empty");
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
                throw new MoodAnalyzerCustomExpection(MoodAnalyzerCustomExpection.ExceptionType.NULL_MOOD, "Mood should not be null");
            }
        }





    }
}
