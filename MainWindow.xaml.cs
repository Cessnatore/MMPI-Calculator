using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MMPI_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CSVDataRetriever retriever = new();
            List<Question> questions = retriever.GetQuestions();

            questions.Add(new Question(2, "A very long string to test this shit because questions are long yo", true));
            questions[0].Value = "true";
            questions[1].Value = "true";

        }



        private void ButtonGenerateReportOnClick(object sender, RoutedEventArgs e)
        {
            List<Question> questions = (List<Question>)ListQuestions.ItemsSource;
            CSVDataRetriever retriever = new();
            List<Subset> subsets = retriever.GetSubsets(questions);
            foreach (Subset subset in subsets)
            {
                Debug.WriteLine($"Id: {subset.Id} Name: { subset.Name}");
                foreach (Question question in subset.Questions)
                {
                    Debug.WriteLine($"\tId: {question.Id} | Content: {question.Content} | Control: {question.Control} | Value: {question.Value}");

                }
                Debug.WriteLine($"Subset Total: {subset.CalculateSubset()}");

            }

        }
    }
}
