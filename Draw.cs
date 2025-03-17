using System;
using System.Drawing;

namespace HanoiTower
{
    public class Draw
    {
        private Game _game;
        private GameForm _form;

        private int _diskHeight = 20;
        private int _pegWidth = 10;
        private int _pegPedding = 360;
        private int _pegSpacing = 200;

        public Draw(Game game, GameForm form)
        { 
            _game = game;
            _form = form;
        }

        public void Resize(Resolution resolution)
        {
            _form.ClientSize = new Size(resolution.Width, resolution.Height);

            _pegPedding = (int)Math.Round(resolution.Height * 0.6f + 40);
            _pegSpacing = (int)Math.Round(resolution.Width * 0.2f + 40);

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
