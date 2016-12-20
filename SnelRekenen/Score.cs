using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnelRekenen
{
    class Score
    {
        public readonly string Naam;
        public readonly int Punten;

        public Score(string scoreString)
        {
            var splitScore = scoreString.Split('\t');
            Naam = splitScore[0];
            Punten = int.Parse(splitScore[1]);
        }
    }
}
