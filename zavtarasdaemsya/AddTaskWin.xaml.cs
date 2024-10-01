using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для AddTaskWin.xaml
    /// </summary>
    public partial class AddTaskWin : Window, INotifyPropertyChanged
    {
        private List<Task> tasks;
        private List<Razdel> razdel;

        public Task Task { get; set; } = new();
        public Razdel Razdel {  get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal([CallerMemberName] string prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
  
        public List<Task> Tasks
        {
            get => tasks;
            set
            {
                tasks = value;
                Signal();
            }
        }
        public List<Razdel> Razdels
        {
            get => razdel;
            set
            {
                razdel = value;
                Signal();
            }
        }

        public AddTaskWin()
        {
            InitializeComponent();
            Razdel = new Razdel();
            DataContext = this;

        }

        private void Save(object sender, RoutedEventArgs e)
        {
            using (var db = new WebZad())
            {

                if (Task.Id == 0)
                {
                    db.Tasks.Add(Task);
                }
                db.SaveChanges();
            }
            Close();
        }
    }
}
