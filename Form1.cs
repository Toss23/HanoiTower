using System;
using System.Windows.Forms;
using System.Drawing;

namespace HanoiTower
{
    public partial class Form1 : Form
    {
        private Game _game;
        private Draw _draw;
        private Timer _timer;

        public Form1()
        {
            _game = new Game();
            _draw = new Draw(_game);

            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            _timer = new Timer();
            _timer.Interval = 50;
            _timer.Tick += Update;
        }

        private void Update(object sender, EventArgs e)
        {
            if (_game.QueueIsEmpty)
            {
                _timer.Stop();
                return;
            }

            _game.Update();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            _draw.DrawPegs(e.Graphics);
            _draw.DrawDisks(e.Graphics);
        }

        private void buttonSolveClick(object sender, EventArgs e)
        {
            if (_game.StartSolve())
            {
                _timer.Start();
            }
        }

        private void buttonResetClick(object sender, EventArgs e)
        {
            _game.DiskCount = (int)diskCountField.Value;
            _game.Reset();
            _timer.Stop();
            Invalidate();
        }

        private void buttonResumeClick(object sender, EventArgs e)
        {
            if (_game.ResumeSolve())
            {
                _timer.Start();
                Invalidate();
            }
        }

        private void buttonStopClick(object sender, EventArgs e)
        {
            if (_game.StopSolve())
            {
                _timer.Stop();
                Invalidate();
            }
        }
    }
}
