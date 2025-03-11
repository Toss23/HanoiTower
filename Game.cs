using System.Collections.Generic;

namespace HanoiTower
{
    public class Game
    {
        public enum GameState
        {
            Reseted, Playing, Stopped
        }

        public int DiskCount = 4;

        private List<Disk>[] _pegs;
        private List<(int disk, int fromPeg, int toPeg)> _moveQueue;
        private GameState _state;

        public GameState State => _state;
        public List<Disk>[] Pegs => _pegs;
        public bool QueueIsEmpty => _moveQueue.Count <= 0;

        public Game() 
        {
            Reset();
        }

        public void Reset()
        {
            _state = GameState.Reseted;

            _pegs = new List<Disk>[3];
            for (int i = 0; i < 3; i++)
            {
                _pegs[i] = new List<Disk>();
            }

            for (int i = DiskCount; i > 0; i--)
            {
                _pegs[0].Add(new Disk(i, Disk.GetDiskWidth(i)));
            }

            _moveQueue = new List<(int, int, int)>();
        }

        public bool StartSolve()
        {
            if (_state != GameState.Reseted)
            {
                return false;
            }

            _state = GameState.Playing;
            _moveQueue.Clear();
            SolveHanoi(DiskCount, 0, 2, 1);
            return true;
        }

        public bool ResumeSolve()
        {
            if (_state == GameState.Stopped)
            {
                _state = GameState.Playing;
                return true;
            }

            return false;
        }

        public bool StopSolve()
        {
            if (_state == GameState.Playing)
            {
                _state = GameState.Stopped;
                return true;
            }

            return false;
        }

        public void Update()
        {
            var move = _moveQueue[0];
            _moveQueue.RemoveAt(0);

            var disk = _pegs[move.fromPeg][_pegs[move.fromPeg].Count - 1];
            _pegs[move.fromPeg].RemoveAt(_pegs[move.fromPeg].Count - 1);
            _pegs[move.toPeg].Add(disk);
        }

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
    }
}
