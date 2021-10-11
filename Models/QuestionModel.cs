using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMPI_Calculator.Models
{
    class QuestionModel
    {
        public int Id { get; set; }
        public string Content { get; set; }


        public string Value { get; set; }

        [BooleanTrueValues("TRUE")]
        [BooleanFalseValues("FALSE")]
        public bool Control { get; set; }

        public QuestionModel(int Id, string Content, bool Control)
        {
            this.Id = Id; this.Content = Content; this.Control = Control; Value = "";
        }



        public bool Contributes()
        {
            bool answer;
            if (Value != "")
            {
                bool actualValue = bool.Parse(Value);
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
