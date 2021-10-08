using CsvHelper.Configuration.Attributes;
using System;

namespace MMPI_Calculator
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }


        public string Value { get; set; }

        [BooleanTrueValues("TRUE")]
        [BooleanFalseValues("FALSE")]
        public bool Control { get; set; }

        public Question(int Id, string Content, bool Control)
        {
            this.Id = Id; this.Content = Content; this.Control = Control; Value = "";
        }



        public bool Contributes()
        {
            bool answer;
            if (Value != "")
            {
                bool actualValue = Boolean.Parse(Value);
                answer = (actualValue == Control) && Control;
            }
            else
            {
                answer = false;
            }

            return answer;
        }
    }
}
