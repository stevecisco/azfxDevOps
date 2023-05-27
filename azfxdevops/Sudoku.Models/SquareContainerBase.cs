using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public abstract class SquareContainerBase : List<Square>
    {
        public string Identifier { get; private set; }

        public SquareContainerBase(string identifier)
        {
            Identifier = identifier;    
        }

        public new void Add(Square square)
        {
            base.Add(square);
            square.DigitSet += Square_DigitSet;
        }

        private void Square_DigitSet(object? sender, int e)
        {
            if (sender != null)
            {
                var sourceSquare = (Square)sender;
                foreach (var sq in this)
                {
                    if (!((sq.RowIndex == sourceSquare.RowIndex) && (sq.ColIndex == sourceSquare.ColIndex)))
                    {
                        sq.SetExcludedDigits(new List<int> { e });
                    }
                }
            }
        }

        public void CheckForMatchesAndReduce()
        {
            //We want to go from 2 to 8 digits, 2 is a pair, and 8 is the highest where we can exclude the ninth square
            for (int i = 2; i < 8; i++)
            {
                CheckForMatchesAndReduce(i);
            }
        }

        public void CheckForMatchesAndReduce(int digitCount)
        {
            //For the digit count determine the allowed digits int he list and how many times they occur (matching sets)
            var allowedDigits = new Dictionary<string, int>();
            this.ForEach(sq =>
            {
                var key = sq.GetAllowedDigitsPacked();
                if (allowedDigits.ContainsKey(key))
                {
                    allowedDigits[key]++;
                }
                else
                {
                    allowedDigits.Add(key, 1);
                }
            });

            //Get the "sets" where the allowed digits = the count and also the number of instances matches the count
            //For example get the 2 digit sets where there is also two squares that have that set
            //  or get the 3 digit sets where there is also three squares that have the set
            //This means that there is an exact set of those values and other squares wouldnt be allowed to have those values
            //in the square list (row column or nine square)
            var sets = allowedDigits.Where(kvp => (kvp.Value == digitCount) && (kvp.Key.Length == digitCount)).ToList();
            foreach (var set in sets)
            {
                var matchesForSet = this.Where(sq => sq.GetAllowedDigitsPacked() == set.Key).ToList();

                var otherSquares = this.Except(matchesForSet).Where(sq => !sq.IsSolved).ToList();
                var digitsToExclude = matchesForSet[0].GetAllowedDigits();
                otherSquares.ForEach(sqOther =>
                {
                    sqOther.SetExcludedDigits(digitsToExclude);
                });
            }
        }

    }
}
