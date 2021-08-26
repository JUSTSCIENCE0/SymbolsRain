using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace SymbolsRain
{
    public partial class MainForm : Form
    {
        private DateTime timePoint;
        private List<Jet> jets;
        private Random rnd;

        public MainForm()
        {
            InitializeComponent();
            Cursor.Hide();
            timePoint = DateTime.Now;
            jets = new List<Jet>();
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            picture.Size = Screen.PrimaryScreen.Bounds.Size;
            rnd = new Random();
            int size = rnd.Next(20, 100);
            for (int i=0; i < size; i++)
            {
                jets.Add(new Jet(i, Screen.PrimaryScreen.Bounds.Size)); 
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            TimeSpan delta = DateTime.Now - timePoint;
            if (delta.TotalMilliseconds > 30)
            {
                timePoint = DateTime.Now;
                for (int i = 0; i < jets.Count; i++)
                {
                    jets[i].Move();
                    if (jets[i].y > Screen.PrimaryScreen.Bounds.Size.Height)
                    {
                        jets.RemoveAt(i);
                        i--;
                    }
                }
                if (rnd.Next(100) < (100 - jets.Count))
                {
                    jets.Add(new Jet(rnd.Next(), Screen.PrimaryScreen.Bounds.Size));
                }
            }
            picture.Invalidate();
            for (int i=0; i<jets.Count; i++)
            {
                jets[i].Draw(e);
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Right)
            {
                
            }

            if (e.KeyCode == Keys.Left)
            {
                
            }
        }
    }
}
