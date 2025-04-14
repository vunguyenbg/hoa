
#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Yoolax.Framework
{
    public class MyJoystickEditor : Editor
    {
        [MenuItem("GameObject/MyJoytick/Joystick", false, 0)]
        static void Init()
        {
            GameObject obj = AssetDatabase.LoadAssetAtPath("Assets/MyJoystick/Prefabs/MyCanvas.prefab", typeof(GameObject)) as GameObject;
            Instantiate(obj);
        }
    }
}

#endif