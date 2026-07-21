using System;
using System.Collections.Generic;
using System.Text;
using Szyfr_Vigenere.Repositories;

namespace Szyfr_Vigenere.Alphabets
{
    public class PolishAlphabet : AlphabetBase,
        IAlphabetRepository
    {
        public PolishAlphabet() : base(
        [
            "A", "Ą", "B", "C", "Ć", "D", "E", "Ę", "F", "G",
            "H", "I", "J", "K", "L", "Ł", "M", "N", "Ń", "O",
            "Ó", "P", "Q", "R", "S", "Ś", "T", "U", "V", "W",
            "X", "Y", "Z", "Ź", "Ż"
        ])
        {}

        override public void Rewind()
        {
            // Reset the alphabet to its original order
            alphabet = new List<string>
            {
                "A", "Ą", "B", "C", "Ć", "D", "E", "Ę", "F", "G",
                "H", "I", "J", "K", "L", "Ł", "M", "N", "Ń", "O",
                "Ó", "P", "Q", "R", "S", "Ś", "T", "U", "V", "W",
                "X", "Y", "Z", "Ź", "Ż"
            };
        }
    }
}
