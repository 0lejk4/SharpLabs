namespace laba2.Figures
{
    public abstract class Figure
    {
        public abstract double square { get; }
        public abstract double perimeter { get; }
        public abstract (double x, double y) gravityCenter { get; }

        public abstract override string ToString();
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
        public abstract Figure DeepCopy();
    }
}