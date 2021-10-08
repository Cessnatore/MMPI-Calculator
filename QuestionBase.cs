using System.ComponentModel;

namespace MMPI_Calculator
{
    public class QuestionBase
    {


        public string Value { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}