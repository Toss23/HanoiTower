using System.Drawing;

namespace HanoiTower
{
    public class Draw
    {
        private Game _game;

        private int _diskHeight = 20;
        private int _pegWidth = 10;
        private int _pegHeight = 300;
        private int _pegSpacing = 250;

        public Draw(Game game)
        { 
            _game = game;
        }

        public void Resize(int x, int y)
        {

        }

        public void DrawPegs(Graphics g)
        {
            for (int i = 0; i < 3; i++)
            {
                int x = (i + 1) * _pegSpacing;
                g.FillRectangle(Brushes.BurlyWood, x - _pegWidth / 2, _pegHeight - 200, _pegWidth, 200);
            }
        }

        public void DrawDisks(Graphics g)
        {
            for (int i = 0; i < 3; i++)
            {
                int x = (i + 1) * _pegSpacing;
                for (int j = 0; j < _game.Pegs[i].Count; j++)
                {
                    var disk = _game.Pegs[i][j];
                    int y = _pegHeight - (j + 1) * _diskHeight;
                    g.FillRectangle(Brushes.CornflowerBlue, x - disk.Width / 2, y, disk.Width, _diskHeight);
                }
            }
        }
    }
}
