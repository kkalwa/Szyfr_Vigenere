using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

namespace Szyfr_Vigenere
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            setRowNumbers();
        }

        private void setRowNumbers()
        {
            int count = CharactersCollection.Count;
            RowNumbers.Add("");
            for(int i=1; i<=count; i++) 
            { 
                RowNumbers.Add(i.ToString() +"."); 
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        /*Is the below even close to optimal solution?*/
        private ObservableCollection<char> charactersCollection = ['A', 'Ą', 'B', 'C', 'Ć', 'D', 'E', 'Ę', 'F',
                                                                   'G', 'H', 'I', 'J', 'K', 'L', 'Ł', 'M', 'N',
                                                                   'Ń', 'O', 'Ó', 'P', 'R', 'S', 'Ś', 'T', 'U',
                                                                   'V', 'W', 'X', 'Y', 'Z', 'Ź', 'Ż'];
        public ObservableCollection<char> CharactersCollection
        {
            get { return charactersCollection; }
            set { charactersCollection = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> rowNumbers = [];
        public ObservableCollection<string> RowNumbers
        {
            get { return rowNumbers; }
            set { rowNumbers = value; OnPropertyChanged(); }
        }
    }
}