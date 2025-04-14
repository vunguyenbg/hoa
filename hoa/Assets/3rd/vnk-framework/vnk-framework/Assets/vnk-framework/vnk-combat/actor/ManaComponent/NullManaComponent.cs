namespace Yoolax.Framework
{
    public class NullManaComponent : BaseComponent, IManaComponent
    {
        private Stats stats = new Stats(0, new System.Collections.Generic.List<Modifier>());
        public float CurrentMana { get => stats.Value; set => stats.Value = value; }
        public float MaxMana { get => stats.BaseValue; set => stats.BaseValue = value; }
        public Stats Stats { get => stats; set => stats = value; }

        public float Percent()
        {
            return 0;
        }
    }
}