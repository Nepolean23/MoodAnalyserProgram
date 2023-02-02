using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProgram
{
    public class MoodAnalyzerWithParameterConstructor
    {
        public string message;

        public MoodAnalyzerWithParameterConstructor()
        {
            Console.WriteLine("Default Constructor");
        }
        public MoodAnalyzerWithParameterConstructor(string message)//constructor
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
                    throw new CustomExpectionUsingParameterConstructor(CustomExpectionUsingParameterConstructor.ExceptionType.EMPTY_MOOD, "Mood should not be empty");
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
                throw new CustomExpectionUsingParameterConstructor(CustomExpectionUsingParameterConstructor.ExceptionType.NULL_MOOD, "Mood should not be null");
            }
        }




    }
}
