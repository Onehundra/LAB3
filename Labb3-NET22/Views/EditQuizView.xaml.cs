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
using Labb3_NET22.DataModels;
using Microsoft.Win32;

namespace Labb3_NET22.Views
{
    /// <summary>
    /// Interaction logic for EditQuizView.xaml
    /// </summary>
    public partial class EditQuizView : UserControl
    {
        private Quiz loadedQuiz;
        public EditQuizView()
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
        private async void LoadQuiz_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "JSON Files|*.json";

            if (dialog.ShowDialog() == true)
            {
                string json = await System.IO.File.ReadAllTextAsync(dialog.FileName);

                loadedQuiz = System.Text.Json.JsonSerializer.Deserialize<Quiz>(json);

                QuestionListBox.Items.Clear();

                foreach (var q in loadedQuiz.Questions)
                {
                    QuestionListBox.Items.Add(q.Statement);
                }

                MessageBox.Show("Quiz Loaded!");
            }
        }


        private void DeleteQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionListBox.SelectedIndex >= 0)
            {
                int index = QuestionListBox.SelectedIndex;

                var list = (List<Question>)loadedQuiz.Questions;
                list.RemoveAt(index);

                QuestionListBox.Items.RemoveAt(index);

                MessageBox.Show("Question Deleted.");
            }
        }
        private async void EditSelected_Click(object sender, RoutedEventArgs e)
        {
            int i = QuestionListBox.SelectedIndex;
            string old = QuestionListBox.Items[i].ToString();
            string txt = Microsoft.VisualBasic.Interaction.InputBox("Edit:", "Edit Question", old);

            QuestionListBox.Items[i] = txt;

            var qList = (List<Labb3_NET22.DataModels.Question>)loadedQuiz.Questions;
            var q = qList[i];
            qList[i] = new Labb3_NET22.DataModels.Question(txt, q.Answers, q.CorrectAnswer);

            string json = System.Text.Json.JsonSerializer.Serialize(loadedQuiz);
            await System.IO.File.WriteAllTextAsync(
                System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData),
                "Labb3_NET22", loadedQuiz.Title + ".json"),
                json);

            MessageBox.Show("Changes Saved!");
        }



        private async void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            
            string json = System.Text.Json.JsonSerializer.Serialize(loadedQuiz);
            string path = System.IO.Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData),
                "Labb3_NET22",
                loadedQuiz.Title + ".json"
            );

            await System.IO.File.WriteAllTextAsync(path, json);
            MessageBox.Show("Saved");
        }


    }
}
