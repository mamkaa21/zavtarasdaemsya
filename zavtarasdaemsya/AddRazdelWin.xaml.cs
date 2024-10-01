using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
    /// Логика взаимодействия для AddRazdelWin.xaml
    /// </summary>
    public partial class AddRazdelWin : Window, INotifyPropertyChanged
    {
        private List<Razdel> razdels = new();

        public Razdel Razdel { get; set; } = new();

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal([CallerMemberName] string prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public List<Razdel> Razdels
        {
            get => razdels;
            set
            {
                razdels = value;
                Signal();
            }
        }

        public AddRazdelWin()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            using (var db = new WebZad())
            {
                if (Razdel.Id == 0)
                {
                    db.Razdels.Add(Razdel);
                }
                db.SaveChanges();
            }
            Close();
        }
    }
}
