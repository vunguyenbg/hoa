using System.Collections;
using System.Collections.Generic;
using Yoolax.Framework;
using UnityEngine;

namespace Game.Test {
    public abstract class Decision : ScriptableObject {
        public abstract bool Decide(IActor context);
    }
}