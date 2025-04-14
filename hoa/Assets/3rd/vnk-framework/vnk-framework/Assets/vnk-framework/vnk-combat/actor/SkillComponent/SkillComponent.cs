
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
namespace Yoolax.Framework
{
    public class SkillComponent : BaseComponent, ISkillComponent, IUpdate
    {
#if UNITY_EDITOR
        [SerializeField] string currentSkillName;
#endif
        [SerializeField] private bool locked;
        [SerializeField] private bool coolDownLocked;

        [SerializeField] private ISkill currentSkill;

        [ShowInInspector] protected Dictionary<string, ISkill> dicSkill = new Dictionary<string, ISkill>();

        public bool Locked => locked;

        public bool CoolDownLocked => coolDownLocked;

        public void Lock(bool value)
        {
            locked = value;
        }
       public void LockCoolDown(bool value)
        {
            coolDownLocked = value;
        }
        public ISkill AddSkill(string skillID, float currentTimeCoolDown, float maxTimeCoolDown)
        {
            Skill skill = new Skill(currentTimeCoolDown, maxTimeCoolDown);
            dicSkill.Add(skillID, skill);
            return skill;
        }
        public ISkill GetSkill(string skillID)
        {
            return dicSkill[skillID];
        }

        public void UpdateComponent()
        {
            if (coolDownLocked)
                return;
            foreach (var skill in dicSkill)
            {
                skill.Value.UpdateTimeCoolDown(Time.deltaTime);
            }
        }

        public bool CastSkill(string skillKey)
        {
            if (locked)
                return false;

            dicSkill.TryGetValue(skillKey, out currentSkill);
            if (currentSkill != null)
            {
                currentSkill.CastSkill();
#if UNITY_EDITOR
                currentSkillName = currentSkill.ToString();
#endif
                return true;
            }
            return false;
        }

    }

}