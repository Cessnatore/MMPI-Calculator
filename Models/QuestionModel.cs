using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMPI_Calculator.Models
{
    public class QuestionModel
    {

        public int Id { get; set; }
        public string Content { get; set; }

        public List<int> SubsetsIDs { get; set; }

        public string Value { get; set; }

        public string[] Values { get; set; } = { "", "False", "True" };
        [BooleanTrueValues("TRUE")]
        [BooleanFalseValues("FALSE")]
        public bool Control { get; set; }


        public QuestionModel(int Id, string Content, bool Control)
        {
            this.Id = Id; this.Content = Content; this.Control = Control; Value = ""; SubsetsIDs = new List<int>();
        }



        public bool Contributes()
        {
            return Value != "" && bool.Parse(Value) == Control;
        }
    }
}
