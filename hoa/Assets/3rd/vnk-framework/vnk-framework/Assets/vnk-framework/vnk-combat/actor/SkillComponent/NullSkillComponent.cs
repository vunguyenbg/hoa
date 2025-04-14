using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class NullSkillComponent : BaseComponent, ISkillComponent
    {
        public bool Locked => throw new System.NotImplementedException();


        public bool CoolDownLocked => throw new System.NotImplementedException();

        public Skill AddSkill(string skillID, float currentTimeCoolDown, float maxTimeCoolDown)
        {
            throw new System.NotImplementedException();
        }

        public bool CastSkill(string skillKey)
        {
            throw new System.NotImplementedException();
        }

        public Skill GetSkill(string skillID)
        {
            throw new System.NotImplementedException();
        }

        public void Lock(bool value)
        {
            throw new System.NotImplementedException();
        }

        ISkill ISkillComponent.AddSkill(string skillID, float currentTimeCoolDown, float maxTimeCoolDown)
        {
            throw new System.NotImplementedException();
        }

        ISkill ISkillComponent.GetSkill(string skillID)
        {
            throw new System.NotImplementedException();
        }

        void ISkillComponent.LockCoolDown(bool value)
        {
            throw new System.NotImplementedException();
        }
    }

}