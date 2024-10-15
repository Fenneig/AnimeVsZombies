namespace AVZ
{
    public interface IDamageable
    {
        public Side Side { get; }
        public void Hit();
    }

    public enum Side
    {
        Anime,
        Zombies
    }
}
