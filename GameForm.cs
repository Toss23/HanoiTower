using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace HanoiTower
{
    public partial class GameForm : Form
    {
        private Game _game;
        private Draw _draw;
        private Configs _configs;
        private Timer _timer;

        private List<Resolution> _resolutions;

        public GameForm()
        {
            InitializeComponent();

            _resolutions = new List<Resolution>
            {
                new Resolution(1920, 1080),
                new Resolution(1600, 900),
                new Resolution(1280, 720),
                new Resolution(640, 480)
            };
        }

        private void OnFormLoaded(object sender, EventArgs e)
        {
            _game = new Game();
            _draw = new Draw(_game, this);

            resolutionBox.Items.Clear();
            _resolutions.ForEach(x => resolutionBox.Items.Add(x.ToString()));
            resolutionBox.SelectedIndex = 0;
            _draw.Resize(_resolutions[resolutionBox.SelectedIndex]);

            _configs = new Configs("data.json");
            if (_configs.LoadFile())
            {
                resolutionBox.SelectedIndex = _configs.ResolutionBoxIndex;
                diskCountField.Value = _configs.DiskCount;
                speedField.Value = _configs.Speed;

                _game.DiskCount = (int)diskCountField.Value;
            }

            _timer = new Timer();
            _timer.Interval = (int)speedField.Value;
            _timer.Tick += Update;

            _game.Reset();
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            if (_configs != null)
            {
                _configs.ResolutionBoxIndex = resolutionBox.SelectedIndex;
                _configs.DiskCount = (int)diskCountField.Value;
                _configs.Speed = (int)speedField.Value;
                _configs.SaveFile();
            }
        }

        private void Update(object sender, EventArgs e)
        {
            if (_game.CurrentMoveIndex >= _game.MoveCount)
            {
                _timer.Stop();
                return;
            }

            _game.NextMove();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            _draw.DrawPegs(e.Graphics);
            _draw.DrawDisks(e.Graphics);
        }

        private void ButtonSolveClick(object sender, EventArgs e)
        {
            if (_game.StartSolve())
            {
                _timer.Start();
            }
        }

        private void ButtonResetClick(object sender, EventArgs e)
        {
            _game.DiskCount = (int)diskCountField.Value;
            _game.Reset();
            _timer.Stop();
            Invalidate();
        }

        private void ButtonResumeClick(object sender, EventArgs e)
        {
            if (_game.ResumeSolve())
            {
                _timer.Start();
                Invalidate();
            }
        }

        private void ButtonStopClick(object sender, EventArgs e)
        {
            if (_game.StopSolve())
            {
                _timer.Stop();
                Invalidate();
            }
        }

        private void ResolutionBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_draw == null)
                return;

            Resolution resolution = _resolutions[resolutionBox.SelectedIndex];
            _draw.Resize(resolution);
        }

        private void DiskCountFieldValueChanged(object sender, EventArgs e)
        {
            if (_game.State == Game.GameState.Reseted)
            {
                _game.DiskCount = (int)diskCountField.Value;
                _game.Reset();
                Invalidate();
            }
        }

        private void SpeedFieldValueChanged(object sender, EventArgs e)
        {
            _timer.Interval = (int)speedField.Value;
        }
    }
}
