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
        {
        }
        public int Count => alphabet.Count;

        public string GetElement(uint n)
        {
            if(n >= alphabet.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }
            return alphabet[(int)n];
        }

        public void MoveLeft(uint n)
        {
            throw new NotImplementedException();
        }

        public void MoveRight(uint n)
        {
            alphabet.Select
        }
    }
}
