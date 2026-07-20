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
using Szyfr_Vigenere.Alphabets;
using Szyfr_Vigenere.Repositories;

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
            setAlphabet(new PolishAlphabet());
            populateView();
            setRowNumbers();
        }

        private void populateView()
        {
            for(int i=0; i<currentAlphabet.Count; i++)
            {
                ObservableCollection<string> row = new ObservableCollection<string>();
                currentAlphabet.MoveRight((uint)i);
                currentAlphabet.SaveItemsTo(row);
                RowCollections.Add(row);
            }
        }

        private AlphabetBase currentAlphabet; // added field to hold the alphabet

        private void setAlphabet(AlphabetBase alphabet)
        {
            this.currentAlphabet = alphabet; // assign to the field, not to the method
            alphabet.SaveItemsTo(CharactersCollection);
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
        private ObservableCollection<string> charactersCollection = new ObservableCollection<string>(); // initialize
        public ObservableCollection<string> CharactersCollection
        {
            get { return charactersCollection; }
            set { charactersCollection = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> rowNumbers = new ObservableCollection<string>(); // initialize
        public ObservableCollection<string> RowNumbers
        {
            get { return rowNumbers; }
            set { rowNumbers = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ObservableCollection<string>> rowCollections = 
            new ObservableCollection<ObservableCollection<string>>(); // initialize
        public ObservableCollection<ObservableCollection<string>> RowCollections
        {
            get { return rowCollections; }
            set { rowCollections = value; OnPropertyChanged(); }
        }
    }
}