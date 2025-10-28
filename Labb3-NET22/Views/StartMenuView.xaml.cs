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
using System.Windows.Shapes;

namespace Labb3_NET22.Views
{
    /// <summary>
    /// Interaction logic for StartMenuView.xaml
    /// </summary>
    public partial class StartMenuView : UserControl
    {
        public StartMenuView()
        {
            InitializeComponent();
        }

        private void StartQuiz_Click(object obj, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;

            if(mainWindow != null)
            {
                mainWindow.Content = new Views.QuizView();
            }
        }

        private void Exit_Click(object obj, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
        private void CreateQuiz_Click(object obj, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if(mainWindow != null)
            {
                mainWindow.Content = new Views.CreateQuizView();
            }
        }

        private void EditQuiz_Click(object obj, RoutedEventArgs e)
        {
            var mainWindow = App.Current.MainWindow as MainWindow;
            if(mainWindow != null)
            {
                mainWindow.Content = new Views.EditQuizView();
            }
        }
    }
}
