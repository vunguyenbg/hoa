

namespace Yoolax.Framework
{
    using DG.Tweening;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class NullBulletDamageComponent : BaseBulletComponent, IBulletDamageComponent
    {
        public float Damage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}