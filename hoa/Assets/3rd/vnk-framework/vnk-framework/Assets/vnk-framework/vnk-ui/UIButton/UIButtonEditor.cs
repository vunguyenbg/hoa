
using UnityEditor;

namespace Yoolax.Framework
{
#if UNITY_EDITOR
    [CustomEditor(typeof(UIButton))]
    public class MyButtonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            UIButton myButton = (UIButton)target;
        }
    }
#endif
}
