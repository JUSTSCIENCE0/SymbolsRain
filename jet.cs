using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace SymbolsRain
{
    class Jet
    {
        private int x;
        public int y;
        private int velocity;
        private char[] symbols;
        private Font font;
        private Brush[] brushes;
        private Random rnd;

        public Jet(int seed, Size window)
        {
            rnd = new Random(DateTime.Now.Millisecond + seed);
            symbols = new char[15];
            brushes = new Brush[15];
            font = new Font("Arial", 20);
            for (int i=0; i<15; i++)
            {
                brushes[i] = new SolidBrush(Color.FromArgb(0, 100 + 10 * i, 0));
                symbols[i] = GenChar();
            }
            x = rnd.Next(1, window.Width - 25);
            y = -1 * rnd.Next(380, 2 * window.Height);
            velocity = rnd.Next(5, 20);
        }

        public void Move()
        {
            y += velocity;
            for (int i=0; i<15; i++)
            {
                if (rnd.NextDouble() <= 0.1)
                {
                    symbols[i] = GenChar();
                }
            }
        }

        public void Draw(PaintEventArgs e)
        {
            for(int i=0; i<15; i++)
            {
                e.Graphics.DrawString(symbols[i].ToString(), font, brushes[i], x, y + 25 * i);
            }
        }

        private char GenChar()
        {
            char symbol;
            do
            {
                symbol = (char)(rnd.Next(1, 65536));
            }
            while (Char.GetUnicodeCategory(symbol) == UnicodeCategory.OtherNotAssigned ||
                Char.GetUnicodeCategory(symbol) == UnicodeCategory.PrivateUse ||
                Char.GetUnicodeCategory(symbol) == UnicodeCategory.Surrogate ||
                Char.GetUnicodeCategory(symbol) == UnicodeCategory.SpacingCombiningMark ||
                Char.GetUnicodeCategory(symbol) == UnicodeCategory.Control ||
                Char.GetUnicodeCategory(symbol) == UnicodeCategory.NonSpacingMark ||
                Char.GetUnicodeCategory(symbol) == UnicodeCategory.OtherPunctuation ||
                Char.GetUnicodeCategory(symbol) == UnicodeCategory.OtherLetter);
            return symbol;
        }
    }
}
