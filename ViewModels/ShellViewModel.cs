using Caliburn.Micro;
using MMPI_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMPI_Calculator.ViewModels
{
    public class ShellViewModel : Screen
    {
        public BindableCollection<QuestionModel> Questions { get; set; }
        public List<SubsetModel> Subsets { get; set; }

        public ShellViewModel()
        {
            DataRetriever retriever = new CSVDataRetriever();

            List<QuestionModel> questions = retriever.GetQuestions();
            Questions = new BindableCollection<QuestionModel>(questions);
            Subsets = retriever.GetSubsets(questions);
        }

        public void GenerateReport()
        {
            foreach (QuestionModel question in Questions)
            {
                if (question.Contributes())
                {
                    foreach (int subsetId in question.SubsetsIDs)
                    {
                        Subsets.Find(s => s.Id == subsetId).Score++;
                    }
                }
            }
            System.Windows.MessageBox.Show(Subsets.First().Score.ToString());          
        }
    }
}
