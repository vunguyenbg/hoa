using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Yoolax.Framework
{
    public class SkillDatas : MonoBehaviour
    {
        public List<Transform> lstSkill;
        public Transform GetSkill(string skillKey)
        {
            Transform skill = lstSkill.Where(item=> item.name.Equals(skillKey)).FirstOrDefault();
            if (skill == null)
            {
                skill = new GameObject().transform;
                skill.gameObject.AddComponent<Bullet>();
                Debug.LogError("Check Get Skill Data Null!!!!!!!! " + skillKey);
            }
            return skill;
        }
    }
}