using System.Windows;
using Microsoft.Win32;


namespace Login.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void OpenFileDialog_Executed(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as Login.ViewModels.MainWindowViewModel;
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "텍스트 파일 열기",
                Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                viewModel?.ProcessFile(openFileDialog.FileName);
            }
        }
    }
}
