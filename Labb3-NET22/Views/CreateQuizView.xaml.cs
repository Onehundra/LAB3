using System;
using System.Collections.Generic;
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

namespace Labb3_NET22.Views
{
    /// <summary>
    /// Interaction logic for CreateQuizView.xaml
    /// </summary>
    public partial class CreateQuizView : UserControl
    {
        private DataModels.Quiz currentQuiz = new DataModels.Quiz();
        public CreateQuizView()
        {
            InitializeComponent();
        }
        private void ReturnToMenu_Click(object obj, RoutedEventArgs e)
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
        private void SaveQuiz_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Quiz med {currentQuiz.Questions.Count()} frågor sparat.");
        }

    }
}
