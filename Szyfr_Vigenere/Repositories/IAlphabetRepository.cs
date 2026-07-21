using System;
using System.Collections.Generic;
using System.Text;

namespace Szyfr_Vigenere.Repositories
{
    public interface IAlphabetRepository
    {
        public int Count { get; }
        public void MoveRight(uint n);
        public void MoveLeft(uint n);
        public string GetElement(uint n);
        public uint GetIndexOf(string value);

    }
}
