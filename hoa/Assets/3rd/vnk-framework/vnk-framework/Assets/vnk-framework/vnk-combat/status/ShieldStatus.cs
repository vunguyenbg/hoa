using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class ShieldStatus : Status
    {
        public override void Apply()
        {
            base.Apply();
            //actor.StatsComponent.AddModifier(statsType.ToString(), modifier);
        }
        public override void End()
        {
            base.End();
            Destroy(gameObject);
        }
    }
}
