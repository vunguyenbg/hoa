using UnityEngine;

namespace Yoolax.Framework
{
    public interface IActor
    {
        Transform Trans { get; }
        bool IsDie { get; set; }
        ActorAction ActorAction { set; get; }
        IMovementComponent MovementComponent { get; }
        IStateComponent StateComponent { get; }
        IStatsComponent StatsComponent { get; }
        IHealthComponent HealthComponent { get; }
        IAnimComponent AnimComponent { get; }
        ISkillComponent SkillComponent { get; }
    }
}
