using System;
using System.Collections.Generic;

namespace HorseHarvest.Core
{
    // English: HorseGame = Juego del Caballo
    public class HorseGame
    {
        // Movement dictionary for horse moves (knight moves) on chess board
        private Dictionary<string, (int row, int col)> _directions = new()
        {
            {"UL", (-2, -1)}, {"UR", (-2, +1)},
            {"LU", (-1, -2)}, {"LD", (+1, -2)},
            {"RU", (-1, +2)}, {"RD", (+1, +2)},
            {"DL", (+2, -1)}, {"DR", (+2, +1)}
        };

        // Dictionary with fruit positions and their symbols
        private Dictionary<string, char> _fruits = new();

        // Current horse position
        private (int row, int col) _horsePos;

        public void SetFruits(string fruits)
        {
            // Example input: C4+,C7*,E3=,E1-,H4*
            _fruits.Clear();
            var parts = fruits.Split(',', StringSplitOptions.RemoveEmptyEntries);

            // Save each fruit position with its symbol
            foreach (var p in parts)
            {
                string pos = p[..2].ToUpper(); // first two chars as position
                char fruit = p[2];             // third char as fruit symbol
                _fruits[pos] = fruit;
            }
        }

        public void SetHorsePosition(string position)
        {
            // Convert chess coordinates to internal (row, col)
            _horsePos = ToCoords(position);
        }

        public List<char> MoveHorse(string moves)
        {
            // List to store collected fruits
            var collected = new List<char>();

            // Split moves by comma
            var steps = moves.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var step in steps)
            {
                // If step is a valid direction
                if (_directions.ContainsKey(step))
                {
                    // Get direction offset and move horse
                    var d = _directions[step];
                    _horsePos.row += d.row;
                    _horsePos.col += d.col;

                    // Convert new horse position back to chess notation
                    string posKey = ToChess(_horsePos);

                    // If there is a fruit at this position, collect it
                    if (_fruits.ContainsKey(posKey))
                    {
                        collected.Add(_fruits[posKey]);
                        _fruits.Remove(posKey); // remove collected fruit
                    }
                }
            }
            return collected;
        }

        private (int row, int col) ToCoords(string chess)
        {
            // Convert chess square like "A1" to array indices
            // Example: a1 = row=7 col=0 (bottom left)
            int col = chess[0] - 'A';
            int row = 8 - int.Parse(chess[1].ToString());
            return (row, col);
        }

        private string ToChess((int row, int col) pos)
        {
            // Convert back from array indices to chess square
            char colLetter = (char)('A' + pos.col);
            int rowNumber = 8 - pos.row;
            return $"{colLetter}{rowNumber}";
        }
    }
}
