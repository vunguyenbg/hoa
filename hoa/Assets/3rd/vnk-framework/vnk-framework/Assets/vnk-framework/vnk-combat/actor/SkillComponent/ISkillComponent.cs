
namespace Yoolax.Framework
{
    public interface ISkillComponent
    {
        bool Locked { get; }
        bool CoolDownLocked { get; }
        bool CastSkill(string skillKey);
        void Lock(bool value);
        void LockCoolDown(bool value);
        ISkill AddSkill(string skillID, float currentTimeCoolDown, float maxTimeCoolDown);
        ISkill GetSkill(string skillID);
    }

}