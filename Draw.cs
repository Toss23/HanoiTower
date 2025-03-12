using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HanoiTower
{
    public class Draw
    {
        private Game _game;
        private GameForm _form;

        private int _diskHeight = 20;
        private int _pegWidth = 10;
        private int _pegPedding = 300;
        private int _pegSpacing = 200;

        private Dictionary<(int, int), (int, int, int, int)> _resolution = new Dictionary<(int, int), (int, int, int, int)>()
        {
            [(1920, 1080)] = (20, 10, 600, 500),
            [(1600, 900)] = (20, 10, 550, 400),
            [(1366, 768)] = (20, 10, 470, 330),
            [(1280, 720)] = (20, 10, 430, 310),
        };

        public Draw(Game game, GameForm form)
        { 
            _game = game;
            _form = form;
            Resize(1280, 720);
        }

        public void Resize(int x, int y)
        {
            var size = (x, y);
            _form.ClientSize = new Size(x, y);
            if (_resolution.ContainsKey(size))
            {
                (_diskHeight, _pegWidth, _pegPedding, _pegSpacing) = _resolution[size];
            }
            else
            {
                (_diskHeight, _pegWidth, _pegPedding, _pegSpacing) = _resolution[(1280, 720)];
            }

            _form.Refresh();
        }

        public void DrawPegs(Graphics g)
        {
            for (int i = 0; i < 3; i++)
            {
                int x = (i + 1) * _pegSpacing;
                g.FillRectangle(Brushes.BurlyWood, x - _pegWidth / 2, _pegPedding - 200, _pegWidth, 200);
            }
        }

        public void DrawDisks(Graphics g)
        {
            Pen borderPen = new Pen(Color.Black, 2);
            for (int i = 0; i < 3; i++)
            {
                int x = (i + 1) * _pegSpacing;
                for (int j = 0; j < _game.Pegs[i].Count; j++)
                {
                    var disk = _game.Pegs[i][j];
                    int y = _pegPedding - (j + 1) * _diskHeight;
                    g.FillRectangle(Brushes.CornflowerBlue, x - disk.Width / 2, y, disk.Width, _diskHeight);
                    g.DrawRectangle(borderPen, x - disk.Width / 2, y, disk.Width, _diskHeight);
                }
            }
        }
    }
}
