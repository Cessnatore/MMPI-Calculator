using System.Collections.Generic;

namespace MMPI_Calculator.Models
{
    public class SubsetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<QuestionModel> Questions { get; set; }
        [CsvHelper.Configuration.Attributes.Ignore]
        public int Score { get; set; }

        public SubsetModel()
        {
            Questions = new();
            Score = 0;
        }

    }
}
