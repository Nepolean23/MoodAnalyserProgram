using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProgram
{
    public class  HandleExpection
    {
        public string message;
        /// <summary>
        /// Default Constructor
        /// </summary>
        public HandleExpection()
        {

        }
        /// <summary>
        /// Parameterised Constructor
        /// </summary>
        public HandleExpection(string message)
        {
            this.message = message.ToUpper();
        }
        public string AnalyseMoodWithoutConstructor(string message)
        {
            if (message.ToLower().Contains("sad"))
                return "SAD";

            else return "HAPPY";

        }
        //UC-2 Using Try Catch Blocks to Handle Null Exception.
        public string AnalyseMood()
        {
            try
            {
                if (message.ToLower().Contains("sad"))
                    return "SAD";
                else return "HAPPY";
            }
            catch (NullReferenceException)
            {
                return "HAPPY";
            }

        }

    }




}
