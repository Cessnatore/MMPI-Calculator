using System.Collections.Generic;

namespace MMPI_Calculator.Models
{
    class SubsetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<QuestionModel> Questions { get; set; }

        public SubsetModel()
        {
            Questions = new();
        }

        public int CalculateSubset()
        {
            int score = 0;
            foreach (QuestionModel question in Questions)
            {
                if (question.Contributes()) score++;
            }
            return score;
        }

    }
}
