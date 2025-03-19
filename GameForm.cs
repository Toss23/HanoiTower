using System;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            trackBar.Value = 0;
            trackBar.Minimum = 0;
            trackBar.Maximum = 0;

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
            if (_game.CurrentMoveIndex >= _game.MoveCount - 1)
            {
                _timer.Stop();
                return;
            }

            _game.NextMove();
            trackBar.Value = _game.CurrentMoveIndex;
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
                trackBar.Minimum = -1;
                trackBar.Maximum = _game.MoveCount - 1;

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

        private void TrackBarScroll(object sender, EventArgs e)
        {
            if (_game.State == Game.GameState.Reseted)
            {
                trackBar.Value = 0;
                return;
            }

            _timer.Stop();
            _game.StopSolve();
            _game.SetMove(trackBar.Value);
            Invalidate();
        }
    }
}
