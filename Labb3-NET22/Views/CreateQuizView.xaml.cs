using System;
using System.Collections.Generic;
using Labb3_NET22.DataModels;
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
using System.IO;
using System.Text.Json;

namespace Labb3_NET22.Views
{
    /// <summary>
    /// Interaction logic for CreateQuizView.xaml
    /// </summary>
    public partial class CreateQuizView : UserControl
    {
        private Quiz currentQuiz= new Quiz();
        public CreateQuizView()
        {
            InitializeComponent();
        }
        private void ReturnToMenu_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.Content = new Views.StartMenuView();
            }

        }
        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            string statement = QuestionBox.Text;
            string[] answers = new string[]
            {
                Answer1Box.Text,
                Answer2Box.Text,
                Answer3Box.Text,
                Answer4Box.Text,
            };
            int correctAnswer = int.Parse(CorrectAnswerBox.Text);

            currentQuiz.AddQuestion(statement, correctAnswer, answers);

            MessageBox.Show("Question Added!");

            QuestionBox.Clear();
            Answer1Box.Clear();
            Answer2Box.Clear();
            Answer3Box.Clear();
            Answer4Box.Clear();
            CorrectAnswerBox.Clear();
        }
        private async void SaveQuiz_Click(object sender, RoutedEventArgs e)
        {
            string quizTitle = QuizTitleBox.Text;
            
            currentQuiz.SetTitle(quizTitle);
            string folderPath = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Labb3_NET22");

            System.IO.Directory.CreateDirectory(folderPath);

            string filePath = System.IO.Path.Combine(folderPath, $"{quizTitle}.json");

            string json = System.Text.Json.JsonSerializer.Serialize(currentQuiz);

            await System.IO.File.WriteAllTextAsync(filePath, json);



            MessageBox.Show("Quiz saved!");
        }



    }
}
