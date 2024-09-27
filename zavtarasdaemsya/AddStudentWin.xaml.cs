using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

namespace zavtarasdaemsya
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudentWin : Window, INotifyPropertyChanged
    {
        public Student Student { get; set; } = new();

        private List<Student> students = new();

        public List<Student> Students
        {
            get => students;
            set
            {
                students = value;
                Signal();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal([CallerMemberName] string prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public AddStudentWin()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void AddStudent(object sender, RoutedEventArgs e)
        {

            //Students.Add(Student);
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Student)));
            using (var db = new WebZad())
            {

                if (Student.Id == 0)
                {
                    db.Students.Add(Student);
                }
                db.SaveChanges();
            }
            Close();
        }
    }
}
