namespace HanoiTower
{
    public class Resolution
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Resolution(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{Width} x {Height}";
        }
    }
}
