using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProgram
{
    public class SimpleMoodAnalyzerProgram
    {
        public string message;
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SimpleMoodAnalyzerProgram()
        {

        }
        /// <summary>
        /// Parameterised Constructor
        /// </summary>
        public SimpleMoodAnalyzerProgram(string message)
        {
            this.message = message.ToUpper();
        }
        public string AnalyseMoodWithoutConstructor(string message)
        {
            if (message.ToLower().Contains("sad"))
                return "SAD";

            else return "HAPPY";

        }
        public string AnalyseMood()
        {
            if (message.ToLower().Contains("sad"))
                return "SAD";

            else return "HAPPY";
        }

    }
}
