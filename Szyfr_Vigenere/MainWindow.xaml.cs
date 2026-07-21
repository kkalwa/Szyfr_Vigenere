using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
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
            currentAlphabet?.Rewind();
        }

        private void populateView()
        {
            for(int i=0; i<currentAlphabet.Count; i++)
            {
                ObservableCollection<string> row = new ObservableCollection<string>();
                currentAlphabet.SaveItemsTo(row);
                RowCollections.Add(row);
                currentAlphabet.MoveLeft(1);  
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

        private string textToEncrypt = string.Empty;
        public string TextToEncrypt
        {
            get { return textToEncrypt; }
            set { textToEncrypt = value;
                OnTextOrKeyChanged();
                OnPropertyChanged();}
        }

        private void OnTextOrKeyChanged()
        {
            if (!string.IsNullOrWhiteSpace(keyText))
            {
                replaceCharactersIfTheyreInAlphabet(textToEncrypt);
            }
            else
            {
                EncryptedText = textToEncrypt;
            }
        }

        private void replaceCharactersIfTheyreInAlphabet(string textToEncrypt)
        {
            EncryptedText = string.Empty;
            for(int i = 0; i < textToEncrypt.Length; i++)
            {
                int keyIndex = i % keyText.Length;
                int indexRow = getIndexOfRowStartingWith(keyText[keyIndex].ToString().ToUpper());
                int indexAlphabet = rowCollections[indexRow].IndexOf(textToEncrypt[i].ToString().ToUpper());
                if(indexAlphabet >=0)
                {
                    EncryptedText += currentAlphabet.GetElement((uint)indexAlphabet);
                }else
                {
                    EncryptedText += textToEncrypt[i];
                }
            }
        }

        private int getIndexOfRowStartingWith(string v)
        {
            foreach( var row in RowCollections )
            {
                if( row[0] == v )
                {
                    return RowCollections.IndexOf(row);
                }
            }
            throw new ArgumentException("Row not found");
        }

        private string keyText = string.Empty;
        public string KeyText
        {
            get { return keyText; }
            set { keyText = value;
                OnTextOrKeyChanged(); 
                OnPropertyChanged();}
        }

        private string encryptedText = string.Empty;
        public string EncryptedText
        {
            get { return encryptedText; }
            set { encryptedText = value; OnPropertyChanged(); }
        }
    }
}