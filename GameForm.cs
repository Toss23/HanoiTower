using System;
using System.Windows.Forms;

namespace HanoiTower
{
    public partial class GameForm : Form
    {
        private Game _game;
        private Draw _draw;
        private SerializedObject _configs;
        private Timer _timer;

        public GameForm()
        {
            InitializeComponent();

            resolutionBox.Items.Clear();
            resolutionBox.Items.AddRange(new string[] {
                "1920 x 1080", 
                "1600 x 900",
                "1366 x 768", 
                "1280 x 720"
            });
            resolutionBox.SelectedIndex = 3;
        }

        private void OnFormLoaded(object sender, EventArgs e)
        {
            _game = new Game();
            _draw = new Draw(_game, this);

            _configs = new SerializedObject();
            _configs.LoadFile("data.sav");
            if (_configs.Corrupted() == false)
            {
                resolutionBox.SelectedIndex = _configs.GetValue<int>("ResolutionBoxIndex");
                diskCountField.Value = _configs.GetValue<decimal>("DiskCount");
                speedField.Value = _configs.GetValue<decimal>("Speed");
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
                _configs = new SerializedObject();
                _configs.AddValue("ResolutionBoxIndex", resolutionBox.SelectedIndex);
                _configs.AddValue("DiskCount", diskCountField.Value);
                _configs.AddValue("Speed", speedField.Value);
                _configs.SaveFile("data.sav");
            }
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

            switch ((string)resolutionBox.SelectedItem) 
            {
                case "1920 x 1080":
                    _draw.Resize(1920, 1080);
                    break;
                case "1600 x 900":
                    _draw.Resize(1600, 900);
                    break;
                case "1366 x 768":
                    _draw.Resize(1366, 768);
                    break;
                case "1280 x 720":
                    _draw.Resize(1280, 720);
                    break;
            }
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
