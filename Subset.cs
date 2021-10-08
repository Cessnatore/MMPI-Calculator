using System;
using System.Collections.Generic;
using System.Diagnostics;
using CsvHelper.Configuration.Attributes;

namespace MMPI_Calculator
{
    public class Subset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }

        public Subset()
        {
            Questions = new();
        }

        public int CalculateSubset()
        {
            int score = 0;
            foreach (Question question in Questions)
            {
                if (question.Contributes()) score++;
            }
            return score;
        }
    }
}
