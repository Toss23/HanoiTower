namespace HanoiTower
{
    public struct Disk
    {
        public int Size { get; }
        public int Width { get; }

        public Disk(int size, int width)
        {
            Size = size;
            Width = width;
        }

        public static int GetDiskWidth(int diskSize)
        {
            return 20 + diskSize * 20;
        }
    }
}
