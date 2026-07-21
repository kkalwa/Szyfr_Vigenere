using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Szyfr_Vigenere.Repositories
{
    public abstract class AlphabetBase
    {
        protected List<string> alphabet;
        public AlphabetBase(List<string> alphabet)
        {
            this.alphabet = alphabet;
        }
        
        public int Count => alphabet.Count;

        public string GetElement(uint n)
        {
            if (n >= alphabet.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }
            return alphabet[(int)n];
        }

        public uint GetIndexOf(string value)
        {
            int index = alphabet.IndexOf(value);
            if (index == -1)
            {
                throw new ArgumentException($"Value '{value}' not found in the alphabet.");
            }
            return (uint)index;
        }
        public void MoveLeft(uint n)
        {
            if (n > 0)
            {
                if (n > Count)
                {
                    n %= (uint)Count;
                }
                Range range = Range.EndAt((int)n);
                List<string> temp = alphabet.Take(range).ToList();
                alphabet.RemoveRange(0, (int)n);
                alphabet.AddRange(temp);

            }
        }
        public void MoveRight(uint n)
        {
            if (n > 0)
            {
                if(n > Count)
                {
                    n %= (uint)Count;
                }
                Range range = Range.StartAt(Count - (int)n);
                List<string> temp = alphabet.Take(range).ToList();
                alphabet.RemoveRange(Count - (int)n, (int)n);
                alphabet.InsertRange(0, temp);

            }
        }
        public void SaveItemsTo(Collection<string> target)
        {
            target.Clear();
            foreach (string item in alphabet)
            {
                target.Add(item);
            }
        }
        public abstract void Rewind();


    }
}
