using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace HanoiTower
{
    public partial class Form1 : Form
    {
        // Стержни и диски
        private List<Disk>[] _pegs;
        private int _diskCount = 4; // Количество дисков

        // Размеры и позиции
        private int _diskHeight = 20;
        private int _pegWidth = 10;
        private int _pegHeight = 300;
        private int _pegSpacing = 250;

        // Таймер для анимации
        private Timer _timer;
        private List<(int disk, int fromPeg, int toPeg)> _moveQueue;

        private bool _gameStarted = false;
        private bool _stopped = false;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
            InitializeTimer();
        }

        // Инициализация игры
        private void InitializeGame()
        {
            _pegs = new List<Disk>[3];
            for (int i = 0; i < 3; i++)
            {
                _pegs[i] = new List<Disk>();
            }

            // Создаем диски и добавляем их на первый стержень
            for (int i = _diskCount; i > 0; i--)
            {
                _pegs[0].Add(new Disk(i, GetDiskWidth(i)));
            }

            // Очередь ходов
            _moveQueue = new List<(int, int, int)>();
        }

        // Инициализация таймера
        private void InitializeTimer()
        {
            _timer = new Timer();
            _timer.Interval = 50; // Интервал анимации (в миллисекундах)
            _timer.Tick += Timer_Tick;
        }

        // Обработчик таймера
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_moveQueue.Count > 0)
            {
                var move = _moveQueue[0];
                _moveQueue.RemoveAt(0);

                // Перемещаем диск
                var disk = _pegs[move.fromPeg][_pegs[move.fromPeg].Count - 1];
                _pegs[move.fromPeg].RemoveAt(_pegs[move.fromPeg].Count - 1);
                _pegs[move.toPeg].Add(disk);

                // Перерисовываем форму
                Invalidate();
            }
            else
            {
                _timer.Stop();
            }
        }

        // Запуск решения
        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (_gameStarted == false) 
            { 
                _moveQueue.Clear();
                SolveHanoi(_diskCount, 0, 2, 1);
                _timer.Start();
                _gameStarted = true;
            }
        }

        // Решение Ханойской башни
        private void SolveHanoi(int disks, int fromPeg, int toPeg, int auxPeg)
        {
            if (disks == 1)
            {
                _moveQueue.Add((disks, fromPeg, toPeg));
                return;
            }

            SolveHanoi(disks - 1, fromPeg, auxPeg, toPeg);
            _moveQueue.Add((disks, fromPeg, toPeg));
            SolveHanoi(disks - 1, auxPeg, toPeg, fromPeg);
        }

        // Отрисовка формы
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawPegs(e.Graphics);
            DrawDisks(e.Graphics);
        }

        // Отрисовка стержней
        private void DrawPegs(Graphics g)
        {
            for (int i = 0; i < 3; i++)
            {
                int x = (i + 1) * _pegSpacing;
                g.FillRectangle(Brushes.Brown, x - _pegWidth / 2, _pegHeight - 200, _pegWidth, 200);
            }
        }

        // Отрисовка дисков
        private void DrawDisks(Graphics g)
        {
            for (int i = 0; i < 3; i++)
            {
                int x = (i + 1) * _pegSpacing;
                for (int j = 0; j < _pegs[i].Count; j++)
                {
                    var disk = _pegs[i][j];
                    int y = _pegHeight - (j + 1) * _diskHeight;
                    g.FillRectangle(Brushes.Blue, x - disk.Width / 2, y, disk.Width, _diskHeight);
                }
            }
        }

        // Ширина диска
        private int GetDiskWidth(int diskSize)
        {
            return 20 + diskSize * 20;
        }

        // Сброс игры
        private void btnReset_Click(object sender, EventArgs e)
        {
            _gameStarted = false;
            _stopped = false;
            _timer.Stop();
            _moveQueue.Clear();
            _diskCount = (int)numericUpDown1.Value;
            InitializeGame();
            Invalidate();
        }

        // Старт игры
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_stopped == true)
            {
                _timer.Start();
                Invalidate();
                _stopped = false;
            }
        }

        // Стоп игры
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_stopped == false && _gameStarted == true)
            {
                _timer.Stop();
                Invalidate();
                _stopped = true;
            }
        }
    }

    // Класс для представления диска
    public struct Disk
    {
        public int Size { get; }
        public int Width { get; }

        public Disk(int size, int width)
        {
            Size = size;
            Width = width;
        }
    }
}
