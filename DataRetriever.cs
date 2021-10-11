using CsvHelper;
using CsvHelper.Configuration;
using MMPI_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMPI_Calculator
{
    abstract class DataRetriever
    {
        public string SubsetDirectory { get; set; }
        public string QuestionDirectory { get; set; }
        public string SubsetQuestionsDirectory { get; set; }

        public DataRetriever()
        {
            SubsetDirectory = @"E:\Projects\MMPI\MMPI Calculator\subsets.csv";
            QuestionDirectory = @"E:\Projects\MMPI\MMPI Calculator\questions.csv";
            SubsetQuestionsDirectory = @"E:\Projects\MMPI\MMPI Calculator\subsetquestions.csv";
        }
        protected class SubsetQuestions
        {
            public int SubsetId { get; set; }
            public int QuestionId { get; set; }
        }
        abstract public List<QuestionModel> GetQuestions();
        abstract public List<SubsetModel> GetSubsets(List<QuestionModel> questions);
    }

    class CSVDataRetriever : DataRetriever
    {
        public override List<QuestionModel> GetQuestions()
        {
            List<QuestionModel> questions = new();
            //hacer dinamico
            using (StreamReader reader = new(QuestionDirectory))
            using (CsvReader csv = new(reader, CultureInfo.InvariantCulture))
            {
                questions = csv.GetRecords<QuestionModel>().ToList();
            }
            using (StreamReader reader = new(SubsetQuestionsDirectory))
            using (CsvReader csv = new(reader, CultureInfo.InvariantCulture))
            {
                List<SubsetQuestions> subsetQuestions = csv.GetRecords<SubsetQuestions>().ToList();

                foreach (SubsetQuestions sq in subsetQuestions)
                {
                    questions.Find(q => q.Id == sq.QuestionId).SubsetsIDs.Add(sq.SubsetId);
                }
            }
            return questions;
        }

        public override List<SubsetModel> GetSubsets(List<QuestionModel> questions)
        {
            List<SubsetModel> subsets = new();


            //hacer dinamico
            using (StreamReader reader = new(SubsetDirectory))
            using (CsvReader csv = new(reader, CultureInfo.InvariantCulture))
            {
                subsets = csv.GetRecords<SubsetModel>().ToList();
            }

            using (StreamReader reader = new(SubsetQuestionsDirectory))
            using (CsvReader csv = new(reader, CultureInfo.InvariantCulture))
            {
                
                List<SubsetQuestions> subsetQuestions = csv.GetRecords<SubsetQuestions>().ToList();

                foreach (SubsetQuestions sq in subsetQuestions)
                {
                    subsets.Find(s => s.Id == sq.SubsetId).Questions.Add(questions.Find(q => q.Id == sq.QuestionId));
                }
            }
            return subsets;
        }
    }
}
