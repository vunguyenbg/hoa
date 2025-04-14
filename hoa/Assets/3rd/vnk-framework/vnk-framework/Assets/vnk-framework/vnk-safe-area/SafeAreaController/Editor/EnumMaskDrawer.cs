using UnityEngine;
using System.Collections;
using System;
using UnityEditor;

namespace Yoolax.Framework
{
    [CustomPropertyDrawer(typeof(EnumMask))]
    public class EnumMaskDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.intValue = EditorGUI.MaskField(position, label, property.intValue, property.enumNames);
        }
    }
}