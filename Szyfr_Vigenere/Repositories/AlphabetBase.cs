using System;
using System.Collections.Generic;
using System.Text;

namespace Szyfr_Vigenere.Repositories
{
    public class AlphabetBase
    {
        protected List<string> alphabet;
        public AlphabetBase(List<string> alphabet)
        {
            this.alphabet = alphabet;
        }
    }
}
