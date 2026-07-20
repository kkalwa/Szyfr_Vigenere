using System;
using System.Collections.Generic;
using System.Text;
using Szyfr_Vigenere.Repositories;

namespace Szyfr_Vigenere.Alphabets
{
    internal class EnglishAlphabet: AlphabetBase,
        IAlphabetRepository
    {
        public EnglishAlphabet() : base(
            new List<string>
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
                "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
                "U", "V", "W", "X", "Y", "Z"
            })
        { }
    
    }
}
