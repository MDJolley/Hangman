using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class WordGenerator
    {
        Random RNG = new Random();

        List<string> _WordBank = System.IO.File.ReadAllText(@"wordBank.txt").Split('\n').ToList();

        public string GetWord()
        {
            int count = _WordBank.Count;
            return _WordBank[RNG.Next(count)];
        }
    }
}
