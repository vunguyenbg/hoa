using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class BulletDamageComponent : BaseBulletComponent, IBulletDamageComponent
    {
       [SerializeField] private float damage;
        public float Damage { get => damage; set => damage = value; }
    }

}