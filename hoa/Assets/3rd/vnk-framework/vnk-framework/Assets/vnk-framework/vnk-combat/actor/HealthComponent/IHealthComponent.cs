
using System;

namespace Yoolax.Framework
{
    public interface IHealthComponent
    {
        Stats Stats { set; get; }
        float CurrentHealth { get; set; }
        float MaxHealth { get; set; }
        bool Immortal { get; set; }
        float Percent();
    }

}