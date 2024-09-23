using UnityEngine;
using System.Collections;
using UnityEditor;
 
 
[CustomPropertyDrawer(typeof (Data))]
public class ButtonDraw : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //とりあえずlabelなしで半分にした入力フィールドをつくる
        position.width *= 0.5f;
        EditorGUI.PropertyField(position, property.FindPropertyRelative("button"), GUIContent.none);
 
        position.x += position.width;
        EditorGUI.PropertyField(position, property.FindPropertyRelative("topic"), GUIContent.none);
    }
}