using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace Yoolax.Framework
{
    public class AtlasSetting : ScriptableObject
    {
        [ShowInInspector]
        public Dictionary<string, SpriteAtlas> dicAtlas;

    }

}