using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProgram
{
    public class MoodAnalyzerUsingRefelction
    {
        public string message;

        public MoodAnalyzerUsingRefelction()
        {
            Console.WriteLine("Default Constructor");
        }
        public MoodAnalyzerUsingRefelction(string message)//constructor
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
                    throw new CustomExpectionUsingReflection(CustomExpectionUsingReflection.ExceptionType.EMPTY_MOOD, "Mood should not be empty");
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
                throw new CustomExpectionUsingReflection(CustomExpectionUsingReflection.ExceptionType.NULL_MOOD, "Mood should not be null");
            }
        }




    }
}
