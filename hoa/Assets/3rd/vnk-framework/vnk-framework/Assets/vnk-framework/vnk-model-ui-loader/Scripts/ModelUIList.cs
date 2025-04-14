using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yoolax.Framework;

public class ModelUIList : MonoBehaviour
{
    public string itemPath = "ModelUI";
    [ShowInInspector] public Dictionary<string, ItemUIBase> dicModel = new Dictionary<string, ItemUIBase>();
}
