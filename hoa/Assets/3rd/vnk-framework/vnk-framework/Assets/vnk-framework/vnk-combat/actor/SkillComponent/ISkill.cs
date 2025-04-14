

using System;

namespace Yoolax.Framework
{
    public interface ISkill
    {
        bool IsBusy { get; }
        float CurrentTimeCoolDown { set; get; }
        float MaxTimeCoolDown { set; get; }
        Action<float> OnCoolDown { set; get; }
        Action OnCoolDownComplete { set; get; }
        void UpdateTimeCoolDown(float deltaTime);
        void CastSkill();
    }

}