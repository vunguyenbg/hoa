
namespace Yoolax.Framework
{
    public class NullHealthComponent : BaseComponent, IHealthComponent
    {
        private Stats stats;
        public Stats Stats { get => stats; set => stats = value; }
        private bool immortal;
        public bool Immortal { get => immortal; set => immortal = value; }
        public float CurrentHealth { get => stats.Value; set => stats.Value = value; }
        public float MaxHealth { get => stats.BaseValue; set => stats.BaseValue = value; }

        public float Percent()
        {
            return 0;
        }
    }
}