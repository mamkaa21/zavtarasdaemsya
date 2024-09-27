using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace zavtarasdaemsya
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<Student> students = new();

        public Student Student { get; set; } = new();
        public List<Student> Students
        {
            get => students;
            set
            {
                students = value;
                Signal();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            var db = DB.Instance;
            DataContext = this;


            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void UpdateList()
        {
            using (var db = new WebZad())
            {
                Students = db.Students.ToList();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void Signal([CallerMemberName] string prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private void AddStudentWin(object sender, RoutedEventArgs e)
        {
            AddStudentWin addStudentWin = new AddStudentWin();
            addStudentWin.Show();
        }
    }
}