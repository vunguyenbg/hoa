using System;

namespace Yoolax.Framework
{
    public interface IManaComponent
    {
        Stats Stats { set; get; }
        float CurrentMana { get; set; }
        float MaxMana { get; set; }
        float Percent();
    }

}