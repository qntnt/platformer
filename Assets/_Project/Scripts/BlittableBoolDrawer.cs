using UnityEditor;
using UnityEngine;
using _Project.Scripts;

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(BlittableBool))]
public class BlittableBoolDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        var field = property.FindPropertyRelative("_value");
        field.intValue = EditorGUI.Toggle(position, label, field.intValue != 0) ? 1 : 0;
    }
}
#endif